using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacijeOrk : MonoBehaviour
{
    private Animator anim;
        
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            anim.Play("Base Layer.Orc_wolfrider_03_run");
        else
            anim.SetBool("IsStanding", true);
    }
}
