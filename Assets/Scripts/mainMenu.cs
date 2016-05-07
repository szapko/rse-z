using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour
{
    // Przypisujemy skin
    public GUISkin menuSkin;
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
    public float buttonWidthKeys = 175;
    public float buttonHeightKeys = 65;
    public float buttonWidthKeysKey = 60;
    public float buttonHeightKeysKey = 65;
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
            GUI.BeginGroup(new Rect(groupXLabel, groupYLabel, buttonWidthLabel, (buttonHeightLabel + marginTopLabel) * 11));
                GUI.Label(new Rect(0, marginTopLabel, buttonWidthLabel, buttonHeightLabel), "<size=55>Ustawienia ogolne</size>");

                if (GUI.Button(new Rect(0, marginTopLabel + buttonHeightLabel, buttonWidthLabel, buttonHeightLabel), "<size=35>Sterowanie</size>"))
                {
                    pageKeys = true;
                    pageSettings = false;
                }
                if (GUI.Button(new Rect(0, (marginTopLabel + buttonHeightLabel) * 2, buttonWidthLabel, buttonHeightLabel), soundOn ? "<size=35>Dzwieki wlaczone</size>" : "<size=35>Dzwieki wylaczone</size>"))
                {
                    soundOn = !soundOn;
                    audioBg.mute = !audioBg.mute;
                }
                if (GUI.Button(new Rect(0, (marginTopLabel + buttonHeightLabel) * 10, buttonWidthLabel, buttonHeightLabel), "<size=35>Cofnij</size>"))
                {
                    pageMain = true;
                    pageSettings = false;
                }
            GUI.EndGroup();
        }

        // O grze
        if (pageAbout == true)
        {
            GUI.BeginGroup(new Rect(groupXLabel, groupYLabel, buttonWidthLabel * 2, (buttonHeightLabel + marginTopLabel) * 11));
                GUI.Label(new Rect(0, marginTopAbout - buttonHeightLabel, buttonWidthLabel, buttonHeightLabel), "<size=55>O grze</size>");

                GUI.TextArea(
                    new Rect(
                        0,
                        marginTopAbout, 
                        buttonWidthLabel * 2, 
                        buttonHeightLabel),
                    "<b>Run! Survive! Escape! Zombie ALPHA</b> stworzona \nna zaliczenie z przedmiotu <b> Programowanie Gier</b>. \n \nDo stworzenia tej gry zostal uzyty silnik <b>Unity 5.3.3f Personal</b>. \n \nWszystkie skrypt napisane zostaly w <b>C#</b>. \n \nGrafika po czesci wlasna, a reszta ze strony: <b>pl.freeimages.com</b> \n \nMuzyka i dzwieki: <b>orangefreesounds.com</b> \n \nGra stworzona przez \n<b>Daniela \"SzAPKO\" Dudzikowskiego</b>. \n \nE-mail kontatkowy: <b>daniel.szapko@gmail.com</b> \n \nRok: <b>2016</b>",
                    menuText);

                if (GUI.Button(new Rect(0, (marginTopLabel + buttonHeightLabel) * 10, buttonWidthLabel, buttonHeightLabel), "<size=35>Cofnij</size>"))
                {
                    pageMain = true;
                    pageAbout = false;
                }
            GUI.EndGroup();
        }

        // Sterowanie
        if (pageKeys == true)
        {
            GUI.BeginGroup(new Rect(groupXLabel, groupYLabel, (marginLeftLabel + buttonWidthKeys + buttonMarginVerKeys) * 2, (buttonHeightLabel + marginTopLabel) * 11));
                GUI.Label(new Rect(marginLeftLabel, 0, buttonWidthKeys * 2, buttonHeightKeys), "<size=65>Sterowanie</size>");

                GUI.Label(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys), buttonWidthKeys, buttonHeightKeys), "<size=35>Do przodu</size>");
                GUI.Label(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 2, buttonWidthKeys, buttonHeightKeys), "<size=35>Do tylu</size>");
                GUI.Label(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 3, buttonWidthKeys, buttonHeightKeys), "<size=35>W prawo</size>");
                GUI.Label(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 4, buttonWidthKeys, buttonHeightKeys), "<size=35>W lewo</size>");
                GUI.Label(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 5, buttonWidthKeys, buttonHeightKeys), "<size=35>Biegnij</size>");
                GUI.Label(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 6, buttonWidthKeys, buttonHeightKeys), "<size=35>Podskocz</size>");
                GUI.Label(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 7, buttonWidthKeys, buttonHeightKeys), "<size=35>Podnies</size>");
                GUI.Label(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 8, buttonWidthKeys, buttonHeightKeys), "<size=35>Uderz</size>");
                GUI.Label(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 9, buttonWidthKeys, buttonHeightKeys), "<size=35>Kopnij</size>");
                GUI.Label(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightKeys) * 10, buttonWidthKeys, buttonHeightKeys), "<size=35>Ekwpiunek</size>");

                // Klawisze
                GUI.Label(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys), buttonWidthKeysKey, buttonHeightKeysKey), "<size=25>W</size>", keysStyleKey);
                GUI.Label(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 2, buttonWidthKeysKey, buttonHeightKeysKey), "<size=25>S</size>", keysStyleKey);
                GUI.Label(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 3, buttonWidthKeysKey, buttonHeightKeysKey), "<size=25>D</size>", keysStyleKey);
                GUI.Label(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 4, buttonWidthKeysKey, buttonHeightKeysKey), "<size=25>A</size>", keysStyleKey);
                GUI.Label(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 5, buttonWidthKeysKey, buttonHeightKeysKey), "<size=25>W + SHIFT</size>", keysStyleKey);
                GUI.Label(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 6, buttonWidthKeysKey, buttonHeightKeysKey), "<size=25>SPACE</size>", keysStyleKey);
                GUI.Label(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 7, buttonWidthKeysKey, buttonHeightKeysKey), "<size=25>E</size>", keysStyleKey);
                GUI.Label(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 8, buttonWidthKeysKey, buttonHeightKeysKey), "<size=25>LPM</size>", keysStyleKey);
                GUI.Label(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 9, buttonWidthKeysKey, buttonHeightKeysKey), "<size=25>PPM</size>", keysStyleKey);
                GUI.Label(new Rect(marginLeftLabel + buttonWidthKeys, (marginTopLabel + buttonHeightKeys) * 10, buttonWidthKeysKey, buttonHeightKeysKey), "<size=25>BACKSPACE</size>", keysStyleKey);

            if (GUI.Button(new Rect(0, (marginTopLabel + buttonHeightLabel) * 10, buttonWidthLabel, buttonHeightLabel), "<size=35>Cofnij</size>"))
                {
                    pageSettings = true;
                    pageKeys = false;
                }

            GUI.EndGroup();
        }
    }
}