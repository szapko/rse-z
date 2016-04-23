using UnityEngine;
using System.Collections;

public class menuKey : MonoBehaviour {

    private int buttonWidth = 200;
    private int buttonHeight = 50;
    private int groupWidth = 200;
    private int groupHeight = 170;

    bool paused = false;

    void Start() {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Screen.lockCursor = true;
        Time.timeScale = 1;
    }

    void OnGUI() {
        if(paused) {
            GUI.BeginGroup(new Rect(((Screen.width / 2) - (groupWidth / 2)), ((Screen.height / 2) - (groupHeight / 2)), groupWidth, groupHeight));

            if(GUI.Button(new Rect(0,10,buttonWidth, buttonHeight), "Menu Glowne")) {
                Application.LoadLevel("Menu");
            }
            if (GUI.Button(new Rect(0, 70, buttonWidth, buttonHeight), "Restart")) {
                Application.LoadLevel("Gra");
            }
            if (GUI.Button(new Rect(0, 130, buttonWidth, buttonHeight), "Wyjscie z gry")) {
                Application.Quit();
            }
            GUI.EndGroup();
        }
    }

    void Update() {
        if(Input.GetKeyUp(KeyCode.Escape)) {
            paused = togglePause();
        }
    }

    bool togglePause() {
        if(Time.timeScale == 0) {
            Screen.lockCursor = true;
            Time.timeScale = 1;
            return(false);
        } else {
            Screen.lockCursor = false;
            Time.timeScale = 0;
            return(true);
        }
    }
}