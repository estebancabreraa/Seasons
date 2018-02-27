using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    public AudioSource fxSound; // Emitir sons
    public AudioClip backMusic; // Som de fundo
                                // Use this for initialization
    void Awake()
    {

        // Audio Source responsavel por emitir os sons
        fxSound = GetComponent<AudioSource>();
        fxSound.Play();
        DontDestroyOnLoad(fxSound);
    }

    // Update is called once per frame
 
}
