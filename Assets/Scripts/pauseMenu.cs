using UnityEngine;
using System.Collections;

public class pauseMenu : MonoBehaviour {

    // wymiary
    private int buttonWidth = 200;
    private int buttonHeight = 50;
    private int groupWidth = 200;
    private int groupHeight = 400;

    // Wymiary consoli
    public int width = Screen.width;
    public int height = 30;

    public Texture2D darkBackground;

    bool paused;

    // Pokaz/ukryj konsole
    bool consoleShow;
    // zmienna na linie komend
    string consoleLineCom = "";
    // Kontrolka do kodu wykonanego
    private int descConsole = 0;

    // Styl konsoli
    public GUIStyle consoleSkin, consoleSkinWritable;

    // dołączamy kontroler rozgladania się myszka
    private UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController pML;

    void Start() {
        pML = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController>();

        Cursor.lockState = CursorLockMode.None;
        //Cursor.visible = true;
        Time.timeScale = 1;
        paused = false;
        consoleShow = false;
    }

    void OnGUI() {
        if(paused) {

            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), darkBackground);

            if(consoleShow)
            {
                GUI.TextField(new Rect(0, 0, width, height), "Run! Survive! Escape! Zombie copyright by Daniel \"SzAPKO\" Dudzikowski.", consoleSkin);

                if (descConsole == 0)
                {
                    //   GUI.SetNextControlName("FocusInput");
                    consoleLineCom = GUI.TextField(new Rect(0, height, width - 50, height), consoleLineCom, 100, consoleSkinWritable);
                    //   GUI.FocusControl("FocusInput");

                    if (GUI.Button(new Rect(width - 50, height, 50, height), "<size=11>Wyslij</size>", consoleSkin))
                    {
                        descConsole = 1;
                    }
                }
                else if(descConsole == 1)
                {
                    switch (consoleLineCom)
                    {
                        case "my_position":
                            GUI.TextField(new Rect(0, height, width, height), "X: " + pML.transform.position.x + " | Y:" + pML.transform.position.y + " | Z:" + pML.transform.position.z, consoleSkin);
                            break;
                        case "time":
                            GUI.TextField(new Rect(0, height, width, height), "Akualna godzina: ", consoleSkin);
                            break;
                        case "show_day":
                            GUI.TextField(new Rect(0, height, width, height), "Dzień: ", consoleSkin);
                            break;
                        case "help":
                            GUI.TextField(new Rect(0, height, width, height), "Dostepne komendy: my_position, time, show_day", consoleSkin);
                            break;
                        default:
                            GUI.TextField(new Rect(0, height, width, height), "Niepoprawna komenda!", consoleSkin);
                            break;
                    }
                }
            }

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
        if(paused == true)
        {
            if (Input.GetKeyUp(KeyCode.BackQuote))
            {
                consoleShow = !consoleShow;
                descConsole = 0;
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

    public bool pausedInfo()
    {
        return paused;
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