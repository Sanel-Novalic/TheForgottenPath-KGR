using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip Clip;
    private AudioSource Source;
    void Start()
    {
        
    }
    private void Awake()
    {
        Source = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAudio()
    {
        Source.PlayOneShot(Clip);
    }
}
