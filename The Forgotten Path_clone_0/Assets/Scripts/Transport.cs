using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    [SerializeField]
    private GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Usao u sferu");
    //    if (collision.gameObject == Player)
    //    {
    //        Player.transform.position = new Vector3(-1, (float)-0.25, (float)-14.56);
    //        Player.transform.rotation = Quaternion.identity;
    //    }
        
    //}
    void OnTriggerEnter(Collider otherObject)
    {
        if (otherObject.gameObject.CompareTag("Player"))
        {
            Vector3 newPosition = otherObject.gameObject.transform.position;
            newPosition = new Vector3(200, 2, 65);
            otherObject.gameObject.transform.position = newPosition;
        }
    }
}
