using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratingEnemies : MonoBehaviourPunCallbacks,IPunObservable
{
    [SerializeField]
    private GameObject Enemy1;
    [SerializeField]
    private GameObject Enemy2;
    private int PositionX1;
    private int PositionY1;
    private int PositionX2;
    private int PositionY2;
    [SerializeField]
    private int MaxNumberOfEnemies;
    private int NumberOfEnemies;
    
    void Start()
    {
       
        StartCoroutine(EnemyGenerate());
    }

    IEnumerator EnemyGenerate()
    {
        
        while (NumberOfEnemies<MaxNumberOfEnemies)
        {
            //if (!PhotonNetwork.IsMasterClient) break;
            PositionX1 = Random.Range(0,110);
            PositionY1 = Random.Range(0,170);
            PhotonNetwork.Instantiate(Enemy1.name, new Vector3(PositionX1, -5, PositionY1), Quaternion.identity);
            PositionX2 = Random.Range(0, 110);
            PositionY2 = Random.Range(0, 170);
            PhotonNetwork.Instantiate(Enemy2.name, new Vector3(PositionX2, -5, PositionY2), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            NumberOfEnemies += 1;
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);

        }
        else
        {
            transform.position = (Vector3)stream.ReceiveNext();
            transform.rotation = (Quaternion)stream.ReceiveNext();

        }
    }
}
