using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioAmbiente : MonoBehaviour
{
    public AudioSource src;
    public AudioClip track;
    // Start is called before the first frame update
    void Start()
    {
        src.clip = track;
        src.loop = true;
        src.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}