using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GanfaulInput : MonoBehaviour
{
    private Animator Animacije;
    void Start()
    {
        Animacije = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            Animacije.SetBool("IsWalking", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
            Animacije.SetBool("IsWalking", false);
        if (Input.GetKeyDown(KeyCode.LeftShift))
            Animacije.SetBool("IsRunning", true);
        else if (Input.GetKeyUp(KeyCode.LeftShift))
            Animacije.SetBool("IsRunning", false);
        if (Input.GetKeyDown(KeyCode.Space))
            Animacije.Play("Base Layer.Skakanje");
        
    }
}
