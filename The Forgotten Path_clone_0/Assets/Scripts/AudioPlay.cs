using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
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

    public void PlayAudio()
    {
        Source.PlayOneShot(Clip);
    }
}
