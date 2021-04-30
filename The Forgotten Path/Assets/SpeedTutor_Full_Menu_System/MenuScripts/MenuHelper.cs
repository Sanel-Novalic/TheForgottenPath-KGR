using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class MenuHelper : MonoBehaviourPunCallbacks
{
   
    void Start()
    {
        Debug.Log("Connecting to server");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }
    
    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Server :D");
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Disconnected because of " + cause.ToString());
    }
    
}
