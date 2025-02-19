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

    private async void Start() // function need to be aysnc beacause this function depends off internet, if we need await, things will freeze
    {
        await UnityServices.InitializeAsync(); // we need to add this line

        AuthenticationService.Instance.SignedIn += () =>
        {
            Debug.Log("Signed in " + AuthenticationService.Instance.PlayerId); // just a debug to see if we are signed in
        };
        await AuthenticationService.Instance.SignInAnonymouslyAsync(); // we have so much options for sign in, but we can make anonymous too

        CreateLobby();
        ListLobbies();

        ListLobbies();
    }

    private async void CreateLobby()
    {
        try
        {
            string lobbyName = "MyLobby";
            int maxPlayers = 2;
            Lobby lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, maxPlayers);

            Debug.Log("Created lobby! " + lobby.Name + " " + lobby.MaxPlayers);
        }
        catch (LobbyServiceException e)
        {
            Debug.Log(e);
        }
    }

    private async void ListLobbies()
    {
        try { 
        QueryResponse queryResponse = await LobbyService.Instance.QueryLobbiesAsync(); // here we dont have the same Lobbies reference, this change on unity 6?
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
