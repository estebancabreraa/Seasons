using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour {

    public AudioSource fxSound; // Emitir sons
    public AudioClip backMusic; // Som de fundo

    private void Start()
    {
        fxSound = GetComponent<AudioSource>();
        DontDestroyOnLoad(fxSound);

    }
    // Use this for initialization
    void playMusic()
    {

        // Audio Source responsavel por emitir os sons
       
        fxSound.Play();
        
    }

    // Update is called once per frame
    private void Update()
    {
        playMusic();
        DontDestroyOnLoad(fxSound);
    }
}
