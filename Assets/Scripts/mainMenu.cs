using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour
{
    // Przypisujemy skin
    public GUISkin menuSkin;
    public GUIStyle menuText;

    // Polozenie grupy buttonow
    public float groupX = 710;
    public float groupY = 330;

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

    public float marginLeftLabel = 20;
    public float marginTopLabel = 15;
    public float marginTopLabel2 = 20;

    // Sterowanie stronami menu
    private bool pageMain = true;
    private bool pageSettings = false;
    private bool pageAbout = false;
    private bool pageKeys = false;

    // Sterowanie dzwiekiem
    private bool soundOn = true;
    private string soundText;

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

        marginLeftLabel = (marginLeftLabel * Screen.width) / 1920;
        marginTopLabel = (marginTopLabel * Screen.height) / 1080;
        marginTopLabel2 = (marginTopLabel2 * Screen.height) / 1080;
    }

    void OnGUI()
    {
        GUI.skin = menuSkin;
        menuText.richText = true;

        // Menu Glowne
        if (pageMain == true)
        {
            GUI.BeginGroup(new Rect(groupX, groupY, buttonWidth, (buttonHeight + marginTop) * 4));
            if (GUI.Button(new Rect(marginLeft, marginTop, buttonWidth, buttonHeight), "Nowa Gra"))
            {
                Application.LoadLevel("Gra");
            }
            if (GUI.Button(new Rect(marginLeft, marginTop + buttonHeight + marginTop, buttonWidth, buttonHeight), "Ustawienia"))
            {
                pageMain = false;
                pageSettings = true;
            }
            if (GUI.Button(new Rect(marginLeft, marginTop + (buttonHeight + marginTop) * 2, buttonWidth, buttonHeight), "O Grze"))
            {
                pageMain = false;
                pageAbout = true;
            }
            if (GUI.Button(new Rect(marginLeft, marginTop + (buttonHeight + marginTop) * 3, buttonWidth, buttonHeight), "Wyjscie"))
            {
                Application.Quit();
            }
            GUI.EndGroup();
        }

        // Ustawienia
        if (pageSettings == true)
        {
            GUI.BeginGroup(new Rect(groupXLabel, groupYLabel, buttonWidthLabel, (buttonHeightLabel + marginTopLabel) * 11));
                GUI.Label(new Rect(marginLeftLabel, marginTopLabel, buttonWidthLabel, buttonHeightLabel), "<size=55>Ustawienia ogolne</size>");

                if (GUI.Button(new Rect(marginLeftLabel, marginTopLabel + buttonHeightLabel, buttonWidthLabel, buttonHeightLabel), "<size=35>Sterowanie</size>"))
                {
                    pageKeys = true;
                    pageSettings = false;
                }
                if (GUI.Button(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightLabel) * 2, buttonWidthLabel, buttonHeightLabel), soundOn ? "<size=35>Dzwieki wlaczone</size>" : "<size=35>Dzwieki wylaczone</size>"))
                {
                    soundOn = !soundOn;
                }
                if (GUI.Button(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightLabel) * 10, buttonWidthLabel, buttonHeightLabel), "<size=35>Cofnij</size>"))
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
                GUI.Label(new Rect(marginLeftLabel, marginTopLabel, buttonWidthLabel, buttonHeightLabel), "<size=55>O grze</size>");

                GUI.TextArea(
                    new Rect(
                        marginLeftLabel, 
                        marginTopLabel2 + buttonHeightLabel, 
                        buttonWidthLabel * 2, 
                        buttonHeightLabel),
                    "<b>Run! Survive! Escape! Zombie ALPHA</b> stworzona \nna zaliczenie z przedmiotu <b> Programowanie Gier</b>. \n \nDo stworzenia tej gry zostal uzyty silnik <b>Unity 5.3.3f Personal</b>. \n \nWszystkie skrypt napisane zostaly w <b>C#</b>. \n \nGrafika po czesci wlasna, a reszta ze strony: \n<b>http://pl.freeimages.com</b> \n \nGra stworzona przez <b>Daniela \"SzAPKO\" Dudzikowskiego</b>. \nE-mail kontatkowy: <b>daniel.szapko@gmail.com</b> \n \nRok: <b>2016</b>",
                    menuText);

                if (GUI.Button(new Rect(marginLeftLabel, (marginTopLabel + buttonHeightLabel) * 10, buttonWidthLabel, buttonHeightLabel), "<size=35>Cofnij</size>"))
                {
                    pageMain = true;
                    pageAbout = false;
                }
            GUI.EndGroup();
        }

        // Sterowanie
        if (pageKeys == true)
        {
            GUI.BeginGroup(new Rect(groupXLabel, groupYLabel, buttonWidthLabel, (buttonHeightLabel + marginTopLabel) * 11));
                GUI.Label(new Rect(marginLeftLabel, marginTopLabel, buttonWidthLabel, buttonHeightLabel), "<size=55>Sterowanie</size>");
            GUI.EndGroup();
        }

    }
}
                /*
                    // Ustawienia klawiszy
                    if (pageKeys == true) {
                        GUI.Label(new Rect(labelMaringLeft, labelMaringTop, labelWidth, labelHeight), "<size=55>Ustawienia klawiszy</size>");

                        if (GUI.Button(new Rect(buttonMaringLeft, buttonMaringTop, buttonWidth, buttonHeight), "<size=35>Do przodu</size>")) {
                            //
                        }
                        if (GUI.Button(new Rect(buttonMaringLeft, buttonMaringTop + buttonHeight + buttonMargin, buttonWidth, buttonHeight), "<size=35>Do tylu</size>")) {
                            //
                        }
                        if (GUI.Button(new Rect(buttonMaringLeft, buttonMaringTop + (buttonHeight + buttonMargin) * 2, buttonWidth, buttonHeight), "<size=35>W prawo</size>")) {
                            //
                        }
                        if (GUI.Button(new Rect(buttonMaringLeft, buttonMaringTop + (buttonHeight + buttonMargin) * 3, buttonWidth, buttonHeight), "<size=35>W lewo</size>")) {
                            //
                        }
                        if (GUI.Button(new Rect(buttonMaringLeft, buttonMaringTop + (buttonHeight + buttonMargin) * 4, buttonWidth, buttonHeight), "<size=35>Skok</size>")) {
                            //
                        }
                        if (GUI.Button(new Rect(buttonMaringLeft + buttonWidth + buttonMarginVer, buttonMaringTop, buttonWidth, buttonHeight), "<size=35>Podnies</size>")) {
                            //
                        }
                        if (GUI.Button(new Rect(buttonMaringLeft + buttonWidth + buttonMarginVer, buttonMaringTop + buttonHeight + buttonMargin, buttonWidth, buttonHeight), "<size=35>Atak - uderz</size>")) {
                            //
                        }
                        if (GUI.Button(new Rect(buttonMaringLeft + buttonWidth + buttonMarginVer, buttonMaringTop + (buttonHeight + buttonMargin) * 2, buttonWidth, buttonHeight), "<size=35>Atak - kopniak</size>")) {
                            //
                        }
                        if (GUI.Button(new Rect(buttonMaringLeft + buttonWidth + buttonMarginVer, buttonMaringTop + (buttonHeight + buttonMargin) * 3, buttonWidth, buttonHeight), "<size=35>Ekwipunek</size>")) {
                            //
                        }

                        if (GUI.Button(new Rect(buttonMaringLeft, (buttonMaringTop + (buttonHeight + buttonMargin) * 10) - labelHeight - labelMargin, buttonWidth, buttonHeight), "<size=35>Cofnij</size>")) {
                            pageSettings = true;
                            pageKeys = false;
                        }
                   }
                */
