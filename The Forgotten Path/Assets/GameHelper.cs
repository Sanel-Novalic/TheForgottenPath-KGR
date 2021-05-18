using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHelper : MonoBehaviourPunCallbacks
{
    public Player PlayerPrefab;
    public Player LocalPlayer;
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Player.RefreshInstance(ref LocalPlayer, PlayerPrefab);
    }
    private void Start()
    {
        Player.RefreshInstance(ref LocalPlayer, PlayerPrefab);
    }
    private void Awake()
    {
        if(!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("Main Menu");
            return;
        }
    }
}
