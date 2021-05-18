using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.IO;

public class GameHelper : MonoBehaviourPunCallbacks
{
    public Player PlayerPrefab;
    [HideInInspector]
    public Player LocalPlayer;
    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        //CreatePlayer();
        Player.RefreshInstance(ref LocalPlayer, PlayerPrefab);
        
    }
    private void Start()
    {

        Player.RefreshInstance(ref LocalPlayer, PlayerPrefab);
        
    }
    private void Awake()
    {
        if (!PhotonNetwork.IsConnected)
        {
            SceneManager.LoadScene("Main Menu");
            return;
        }
    }
    public void CreatePlayer()
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
    }
}
