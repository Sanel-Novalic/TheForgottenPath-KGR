using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    private Vector3 Respawn;
    [SerializeField]
    private Collider BoxCollider;
    private GameObject Player;
    [SerializeField]
    private GameObject CheckBox;
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
            Player.transform.position = Respawn;
    }
    public void SetCheckpoint(Vector3 CheckpointPosition)
    {
        Instantiate(CheckBox, CheckpointPosition, Quaternion.identity);
    }
    public void SetRespawnPosition(Vector3 RespawnPosition)
    {
        Respawn = RespawnPosition;
    }
    public void SetCheckpointName(string name)
    {
        CheckBox.name = name;
    }
}
