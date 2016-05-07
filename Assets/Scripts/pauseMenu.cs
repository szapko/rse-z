﻿using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {

    // wymiary
    private int buttonWidth = 200;
    private int buttonHeight = 50;
    private int groupWidth = 200;
    private int groupHeight = 400;

    public Texture2D darkBackground;

    bool paused = false;

    // dołączamy kontroler rozgladania się myszka
    private UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController pML;

    void Start() {
        pML = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController>();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 1;
    }

    void OnGUI() {
        if(paused) {

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), darkBackground);

            GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2)), groupWidth, groupHeight));

            if (GUI.Button(new Rect(0, 10, buttonWidth, buttonHeight), "Wznow gre"))
            {
                paused = togglePause();
                LockMouseLook();
            }
            if (GUI.Button(new Rect(0, 70, buttonWidth, buttonHeight), "Nowa gra")) {
                Application.LoadLevel("Gra");
            }
            if (GUI.Button(new Rect(0, 130, buttonWidth, buttonHeight), "Zapisz gre"))
            {
                // zapisywanie
            }
            if (GUI.Button(new Rect(0, 190, buttonWidth, buttonHeight), "Wczytaj gre"))
            {
                //wczytywanie
            }
            if (GUI.Button(new Rect(0, 250,buttonWidth, buttonHeight), "Wyjdz do Menu")) {
                Application.LoadLevel("Menu");
            }
            if (GUI.Button(new Rect(0, 310, buttonWidth, buttonHeight), "Wyjdz do Windowsa")) {
                Application.Quit();
            }
            GUI.EndGroup();
        }
    }

    void Update() {
        if(paused == false)
        {
            if(Input.GetKeyUp(KeyCode.Escape)) {
                paused = togglePause();
                LockMouseLook();
            }
        }
    }

    bool togglePause()
    { 
        if(Time.timeScale == 0) {
            // wyłączamy pauze
            Time.timeScale = 1;
            return (false);
        } else {
            // Włączamy pauze
            Time.timeScale = 0;
            return (true);
        }
    }

    void LockMouseLook()
    {
        if(pML.m_MouseLook.XSensitivity == 2F)
        {
            pML.m_MouseLook.XSensitivity = 0F;
            pML.m_MouseLook.YSensitivity = 0F;
        } else
        {
            pML.m_MouseLook.XSensitivity = 2F;
            pML.m_MouseLook.YSensitivity = 2F;
        }
    }
}