using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models; // we need to add this namespace
using System.Collections.Generic; 
using System.Collections;

public class LobbyExplanation : MonoBehaviour
{
    // First step is link the project on unity services and after install the package multiplayer services
    // Second step is create a script like this and put on a gameobject

    private Lobby hostLobby;
    private float heartBeatTimer;

    private async void Start() // function need to be aysnc beacause this function depends off internet, if we need await, things will freeze
    {
        await UnityServices.InitializeAsync(); // we need to add this line

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId); // just a debug to see if we are signed in
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync(); // we have so much options for sign in, but we can make anonymous too

        ListLobbies();
        CreateLobby();
        
    }

    private void Update()
    {
        HandleLobbyHeartBeat();
    }

    private async void HandleLobbyHeartBeat()
    {
        if (hostLobby != null)
        {
            heartBeatTimer -= Time.deltaTime;
            if (heartBeatTimer <= 0) // we can change this value
            {
                float heartBeatTimerMax = 15;
                heartBeatTimer = heartBeatTimerMax;

                await LobbyService.Instance.SendHeartbeatPingAsync(hostLobby.Id); // we need to send a ping to the server to keep the lobby alive
            }
        }
    }


    private async void CreateLobby()
    {
        try
        {
            string lobbyName = "MyLobby";
            int maxPlayers = 2;

            CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions
            {
                IsPrivate = true,

            };

            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers, createLobbyOptions);

            hostLobby = lobby;
            Debug.Log("Created lobby! " + lobby.Name + " " + lobby.MaxPlayers + " " + lobby.Id + " " + lobby.LobbyCode);
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }

    private async void ListLobbies()
    {
        try
        {
            QueryLobbiesOptions queryLobbiesOptions = new QueryLobbiesOptions
            {
                Count = 25,
                Filters = new List<QueryFilter>
                {
                    new QueryFilter(QueryFilter.FieldOptions.AvailableSlots, "0", QueryFilter.OpOptions.GT)
                },
                Order = new List<QueryOrder> 
                { 
                    new QueryOrder(false, QueryOrder.FieldOptions.Created)
                }
            };
            QueryResponse queryResponse = await LobbyService.Instance.QueryLobbiesAsync(queryLobbiesOptions); // here we dont have the same Lobbies reference, this change on unity 6?
            Debug.Log("Lobbies found " + queryResponse.Results.Count);

            foreach (Lobby lobby in queryResponse.Results)
            {
                Debug.Log(lobby.Name + " " + lobby.MaxPlayers);
            }
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }

    // if lobby dont recieve data in 30 seconds, it will be inactive

    private async void JoinLobbyByCode(string lobbyCode)
    {
        try
        {
            await LobbyService.Instance.JoinLobbyByCodeAsync(lobbyCode);
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }
}
