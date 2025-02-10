using UnityEngine;

public class Notes : MonoBehaviour
{
    // Network manager works for handles starting connection, handle data and have much configs
    // network topologies: Dedicated Game Server, Client hosted listen server, distributed authority
    // Multiplayer play mode is a mode that allows you to test your game in the editor without having to build it
    // Multiplayer tools is for check connection
    // RuntimeNetworkStatsMonitor is for see the stats of connection, server and other things
    // We can use the the simples OnMouseDown() method to handle click events, but we can implement the interface OnPointerDownHandler to handle click events too, but if we use the interface we need to implement the method OnPointerDown and put a event system on scene, and add raycaster on the camera
    // For make a object can be spawned on network, we have to add the Network Object script
    // Only server can be spawn objects
    // RPCS allows us to call methods on the server from the client, for spawn objects for example
    // remote procedure calls = RPCS
    // A important thing about network, is that all data need to be syncronized between server and clients, and this is not automatically, so we need to do this manually
    // We syncronize the pos of cross using the network transform component
    // Ever keep in mind wich function run on client and wich run on server
    // We have to pay attetion if the function is on client and server, always, if one dont was, this can cause bugs
}
