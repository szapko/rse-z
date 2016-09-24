using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour
{
    // skin
    public GUISkin menuSkin;
    public GUISkin menuSkin2;
    public GUIStyle menuText, keysStyleKey;

    // Polozenie grupy buttonow
    public float groupX = 760;
    public float groupY = 250;

    // Wymiary buttona
    public float buttonWidth = 400;
    public float buttonHeight = 75;

    public float marginLeft = 0;
    public float marginTop = 25;

    // Polozenie grupy ustawien
    public float groupXLabel = 710;
    public float groupYLabel = 50;

    // Wymiary label
    public float buttonWidthLabel = 400;
    public float buttonHeightLabel = 75;
    public float buttonHeightLabelText = 25;

    public float marginLeftLabel = 70;
    public float marginTopLabel = 15;
    public float marginTopLabel2 = 20;

    // Pola tekstowe wymiary
    public float buttonWidthKeys = 150;
    public float buttonHeightKeys = 45;
    public float buttonWidthKeysKey = 150;
    public float buttonHeightKeysKey = 45;
    public float buttonMarginVerKeys = 5;

    // Marginesy zakladki O grze
    public float marginTopAbout = 190;

    // Sterowanie stronami menu
    private bool pageMain = true;
    private bool pageSettings = false;
    private bool pageAbout = false;
    private bool pageKeys = false;

    // Sterowanie dzwiekiem
    private bool soundOn = true;
    private string soundText;

    // Źródło dźwięku
    AudioSource audioBg;

    void Start()
    {
        // responsywnosc
        groupX = (groupX * Screen.width) / 1920;
        groupY = (groupY * Screen.height) / 1080;

        buttonWidth = (buttonWidth * Screen.width) / 1920;
        buttonHeight = (buttonHeight * Screen.height) / 1080;

        marginLeft = (marginLeft * Screen.width) / 1920;
        marginTop = (marginTop * Screen.height) / 1080;

        groupXLabel = (groupXLabel * Screen.width) / 1920;
        groupYLabel = (groupYLabel * Screen.height) / 1080;

        buttonWidthLabel = (buttonWidthLabel * Screen.width) / 1920;
        buttonHeightLabel = (buttonHeightLabel * Screen.height) / 1080;
        buttonHeightLabelText = (buttonHeightLabelText * Screen.height) / 1080;

        buttonWidthKeys = (buttonWidthKeys * Screen.width) / 1920;
        buttonHeightKeys = (buttonHeightKeys * Screen.height) / 1080;
        buttonWidthKeysKey = (buttonWidthKeysKey * Screen.width) / 1920;
        buttonHeightKeysKey = (buttonHeightKeysKey * Screen.height) / 1080;
        buttonMarginVerKeys = (buttonMarginVerKeys * Screen.height) / 1080;

        marginLeftLabel = (marginLeftLabel * Screen.width) / 1920;
        marginTopLabel = (marginTopLabel * Screen.height) / 1080;
        marginTopLabel2 = (marginTopLabel2 * Screen.height) / 1080;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        audioBg = GetComponent<AudioSource>();
    }

    void OnGUI()
    {
        GUI.skin = menuSkin;
        menuText.richText = true;

        // Menu Glowne
        if (pageMain == true)
        {
            GUI.BeginGroup(new Rect(groupX, groupY, buttonWidth, (buttonHeight + marginTop) * 5));
            if (GUI.Button(new Rect(marginLeft, marginTop, buttonWidth, buttonHeight), "Nowa Gra"))
            {
                Application.LoadLevel("Gra");
            }

            if (GUI.Button(new Rect(marginLeft, marginTop + buttonHeight + marginTop, buttonWidth, buttonHeight), "Wczytaj gre"))
            {
                // kod wczytujace zapisany stan gry (nie ma jeszcze zapisywanie stanu gry)
            }

            if (GUI.Button(new Rect(marginLeft, marginTop + (buttonHeight + marginTop) * 2, buttonWidth, buttonHeight), "Ustawienia"))
            {
                pageMain = false;
                pageSettings = true;
            }
            if (GUI.Button(new Rect(marginLeft, marginTop + (buttonHeight + marginTop) * 3, buttonWidth, buttonHeight), "O Grze"))
            {
                pageMain = false;
                pageAbout = true;
            }
            if (GUI.Button(new Rect(marginLeft, marginTop + (buttonHeight + marginTop) * 4, buttonWidth, buttonHeight), "Wyjscie"))
            {
                Application.Quit();
            }
            GUI.EndGroup();
        }


        // Ustawienia
        if (pageSettings == true)
        {
            GUI.skin = menuSkin2;

            GUI.BeginGroup(new Rect(groupXLabel, groupYLabel, buttonWidthLabel, (buttonHeightLabel + marginTopLabel) * 11));
                GUI.Label(new Rect(0, marginTopLabel, buttonWidthLabel, buttonHeightLabel), "Ustawienia ogólne");

                if (GUI.Button(new Rect(0, marginTopLabel + buttonHeightLabel, buttonWidthLabel, buttonHeightLabel), "Sterowanie"))
                {
                    pageKeys = true;
                    pageSettings = false;
                }
                if (GUI.Button(new Rect(0, (marginTopLabel + buttonHeightLabel) * 2, buttonWidthLabel, buttonHeightLabel), soundOn ? "Dźwięki: włączone" : "Dźwięki: wyłączone"))
                {
                    soundOn = !soundOn;
                    audioBg.mute = !audioBg.mute;
                }
                if (GUI.Button(new Rect(0, (marginTopLabel + buttonHeightLabel) * 10, buttonWidthLabel, buttonHeightLabel), "Cofnij"))
                {
                    pageMain = true;
                    pageSettings = false;
                }
            GUI.EndGroup();
        }

        // O grze
        if (pageAbout == true)
        {
            GUI.skin = menuSkin2;

            GUI.BeginGroup(new Rect(groupXLabel, groupYLabel, buttonWidthLabel * 2, (buttonHeightLabel + marginTopLabel) * 11));
                GUI.Label(new Rect(0, marginTopAbout - buttonHeightLabel, buttonWidthLabel, buttonHeightLabel), "O grze");

                GUI.Box(
                    new Rect(
                        0,
                        marginTopAbout, 
                        buttonWidthLabel * 2, 
                        buttonHeightLabel * 5),
                    "<size=20><b>Run! Survive! Escape! Zombie ALPHA</b> stworzona \nna zaliczenie z przedmiotu <b> Programowanie Gier</b>. \n \nDo stworzenia tej gry został użyty silnik <b>Unity 5.4.1f1 Personal</b>. \n \nWszystkie skrypt napisane zostały w <b>C#</b>. \n \nGrafika po części własna, a reszta ze strony: <b>pl.freeimages.com</b> \n \nMuzyka i dźwięki: <b>orangefreesounds.com</b> \n \nGra stworzona przez \n<b>Daniela \"SzAPKO\" Dudzikowskiego</b>. \n \nE-mail kontatkowy: <b>daniel.szapko@gmail.com</b> \n \nRok: <b>2016</b></size>");

                if (GUI.Button(new Rect(0, (marginTopLabel + buttonHeightLabel) * 10, buttonWidthLabel, buttonHeightLabel), "Cofnij"))
                {
                    pageMain = true;
                    pageAbout = false;
                }
            GUI.EndGroup();
        }

        // Sterowanie
        if (pageKeys == true)
        {
            GUI.skin = menuSkin2;

            GUI.BeginGroup(new Rect(groupXLabel, groupYLabel, (marginLeftLabel + buttonWidthKeys + buttonMarginVerKeys) * 2, (buttonHeightLabel + marginTopLabel) * 11));
                GUI.Label(new Rect(marginLeftLabel, 0, buttonWidthKeys * 2, buttonHeightKeys), "Sterowanie");

                GUI.Box(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 2, buttonWidthKeys, buttonHeightKeys), "<size=20>Do przódu</size>");
                GUI.Box(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 3, buttonWidthKeys, buttonHeightKeys), "<size=20>Do tyłu</size>");
                GUI.Box(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 4, buttonWidthKeys, buttonHeightKeys), "<size=20>W prawo</size>");
                GUI.Box(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 5, buttonWidthKeys, buttonHeightKeys), "<size=20>W lewo</size>");
                GUI.Box(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 6, buttonWidthKeys, buttonHeightKeys), "<size=20>Biegnij</size>");
                GUI.Box(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 7, buttonWidthKeys, buttonHeightKeys), "<size=20>Podskocz</size>");
                GUI.Box(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 8, buttonWidthKeys, buttonHeightKeys), "<size=20>Podnieś</size>");
                GUI.Box(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 9, buttonWidthKeys, buttonHeightKeys), "<size=20>Uderz</size>");
                GUI.Box(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 10, buttonWidthKeys, buttonHeightKeys), "<size=20>Kopnij</size>");
                GUI.Box(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 11, buttonWidthKeys, buttonHeightKeys), "<size=20>Ekwpiunek</size>");

                // Klawisze
                GUI.Box(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 2, buttonWidthKeysKey, buttonHeightKeysKey), "<size=20><b>W</b></size>");
                GUI.Box(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 3, buttonWidthKeysKey, buttonHeightKeysKey), "<size=20><b>S</b></size>");
                GUI.Box(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 4, buttonWidthKeysKey, buttonHeightKeysKey), "<size=20><b>D</b></size>");
                GUI.Box(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 5, buttonWidthKeysKey, buttonHeightKeysKey), "<size=20><b>A</b></size>");
                GUI.Box(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 6, buttonWidthKeysKey, buttonHeightKeysKey), "<size=20><b>W + SHIFT</b></size>");
                GUI.Box(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 7, buttonWidthKeysKey, buttonHeightKeysKey), "<size=20><b>SPACE</b></size>");
                GUI.Box(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 8, buttonWidthKeysKey, buttonHeightKeysKey), "<size=20><b>E</b></size>");
                GUI.Box(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 9, buttonWidthKeysKey, buttonHeightKeysKey), "<size=20><b>LPM</b></size>");
                GUI.Box(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 10, buttonWidthKeysKey, buttonHeightKeysKey), "<size=20><b>PPM</b></size>");
                GUI.Box(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 11, buttonWidthKeysKey, buttonHeightKeysKey), "<size=20><b>BACKSPACE</b></size>");

            if (GUI.Button(new Rect(0, (marginTopLabel + buttonHeightLabel) * 10, buttonWidthLabel, buttonHeightLabel), "Cofnij"))
                {
                    pageSettings = true;
                    pageKeys = false;
                }

            GUI.EndGroup();
        }
    }
}