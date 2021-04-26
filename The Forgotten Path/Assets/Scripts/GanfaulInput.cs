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
        bool Forward = Input.GetKey(KeyCode.W);
        bool Left = Input.GetKey(KeyCode.A);
        bool Right = Input.GetKey(KeyCode.D);
        bool Back = Input.GetKey(KeyCode.S);
        if (Forward || Left || Right || Back)
            Animacije.SetBool("IsWalking", true);
        else 
            Animacije.SetBool("IsWalking", false);
        if (Input.GetKey(KeyCode.LeftShift))
            Animacije.SetBool("IsRunning", true);
        else
            Animacije.SetBool("IsRunning", false);
        if (Input.GetKey(KeyCode.Space))
            Animacije.Play("Base Layer.Skakanje");
        
    }
}
