using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaAudio : MonoBehaviour
{
    public AudioSource MeuAudioSource;
    public static AudioSource instance;

    // Start is called before the first frame update
    void Awake()
    {
        MeuAudioSource = GetComponent<AudioSource>();
        instance = MeuAudioSource;
    }

    
}
