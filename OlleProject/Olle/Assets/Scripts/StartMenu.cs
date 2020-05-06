﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{


    // store the GameObject which renders the overlay info
    public GameObject overlay;

    // store a reference to the audio listener in the scene, allowing for muting of the scene during the overlay
    public AudioListener mainListener;

    

    // string to store Prefs Key with name of preference for showing the overlay info
    public static string showAtStartPrefsKey = "showLaunchScreen";

    // used to ensure that the launch screen isn't more than once per play session if the project reloads the main scene
    private static bool alreadyShownThisSession = false;


    void Awake()
    {
        // have we already shown this once?
        if (alreadyShownThisSession)
        {
            StartGame();
        }
        else
        {
            alreadyShownThisSession = true;
            
        }
    }

    // show overlay info, pausing game time, disabling the audio listener 
    // and enabling the overlay info parent game object
    public void ShowLaunchScreen()
    {
        Time.timeScale = 0f;
        mainListener.enabled = false;
        overlay.SetActive(true);
    }

    

    // continue to play, by ensuring the preference is set correctly, the overlay is not active, 
    // and that the audio listener is enabled, and time scale is 1 (normal)
    public void StartGame()
    {
        overlay.SetActive(false);
        mainListener.enabled = true;
        Time.timeScale = 1f;
    }

    
}
