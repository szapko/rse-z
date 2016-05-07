﻿using UnityEngine;
using System.Collections;

public class console : MonoBehaviour {

    // Wymiary
    public int width = Screen.width;
    public int height = 30;

    // Styl konsoli
    public GUIStyle consoleSkin, consoleSkinWritable;

    // zmienna na linie komend
    string consoleLineCom = "";
    
    // CONSOLA ON/OFF
    private bool consoleSwitch = false;

    // Kontrolka do kodu wykonanego
    private int descConsole = 0;
    
    // Pauza //
    bool paused = false;

    // dołączamy kontroler rozgladania się myszka
    private UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController pML;

    void Start()
    {
        pML = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController>();

        Time.timeScale = 1;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.BackQuote))
        {
            descConsole = 0;
            consoleLineCom = "";
            consoleSwitch = !(consoleSwitch);
            //  LockMouseLook();
            //  paused = togglePause();
        }

        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (consoleLineCom != "") {
                descConsole = 1;
            }
        }
    }

    void OnGUI()
    {
       // if (paused)
        //{
            if (consoleSwitch)
            {
            Time.timeScale = 0;
            //Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.None;

            GUI.TextField(new Rect(0, 0, width, height), "Run! Survive! Escape! Zombie copyright by Daniel \"SzAPKO\" Dudzikowski.", consoleSkin);

                int a = 1;
                if (descConsole == 1)
                {
                    switch (consoleLineCom)
                    {
                        case "my_position":
                            GUI.TextField(new Rect(0, height, width, height), "X: " + pML.transform.position.x + " | Y:" + pML.transform.position.y + " | Z:" + pML.transform.position.z, consoleSkin);
                            break;
                        case "help":
                            GUI.TextField(new Rect(0, height, width, height), "Dostepne komendy: my_position", consoleSkin);
                            break;
                        default:
                            GUI.TextField(new Rect(0, height, width, height), "Niepoprawna komenda!", consoleSkin);
                            break;
                }
                    a = 2;
                }

                consoleLineCom = GUI.TextField(new Rect(0, height * a, width, height), consoleLineCom, 100, consoleSkinWritable);
            } else
            {
                Time.timeScale = 1;
            }
       // }
    }

    /*
    bool togglePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            return (false);
        }
        else {
            Time.timeScale = 0;
            return (true);
        }
    }

    void LockMouseLook()
    {
        if (pML.m_MouseLook.XSensitivity == 2F)
        {
            pML.m_MouseLook.XSensitivity = 0F;
            pML.m_MouseLook.YSensitivity = 0F;
        }
        else
        {
            pML.m_MouseLook.XSensitivity = 2F;
            pML.m_MouseLook.YSensitivity = 2F;
        }
    }
    */
}
 
