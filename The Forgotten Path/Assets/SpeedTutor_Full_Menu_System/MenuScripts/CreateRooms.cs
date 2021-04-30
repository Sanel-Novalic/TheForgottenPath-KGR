using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CreateRooms : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private string RoomName = "Sobica";
    public void OnClick_CreateRoom()
    {
        RoomOptions Opcije = new RoomOptions();
        Opcije.MaxPlayers = 2;
        PhotonNetwork.JoinOrCreateRoom(RoomName, Opcije, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Uspjesno kreirana soba.");
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Kreiranje sobe neuspjesno.");
    }
}
