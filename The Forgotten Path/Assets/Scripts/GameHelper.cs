using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Realtime;
using System.IO;

namespace SG
{
    public class GameHelper : MonoBehaviourPunCallbacks
    {
        public PlayerStats PlayerPrefab;
        [HideInInspector]
        public PlayerStats LocalPlayer;

        public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
        {
            base.OnPlayerEnteredRoom(newPlayer);
            PlayerStats.RefreshInstance(ref LocalPlayer, PlayerPrefab);
        }

        public Transform playerTransform()
        {
            return LocalPlayer.gameObject.transform;
        }
        private void Awake()
        {
            if (!PhotonNetwork.IsConnected)
            {
                SceneManager.LoadScene("Main Menu");
                return;
            }
            PlayerStats.RefreshInstance(ref LocalPlayer, PlayerPrefab);
        }
        public void CreatePlayer()
        {
            Debug.Log("Creating Player");
            PhotonNetwork.Instantiate(PlayerPrefab.name, new Vector3(0, 0, 0), Quaternion.identity, 0);
        }
    }
}