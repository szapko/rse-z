using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
    // Przypisujemy skin
    public GUISkin skin;
    public GUIStyle skinText;
    
    // Button
    public float buttonMaringLeft = 710;
    public float buttonMaringTop = 216;

    private float buttonMargin = 35;
    private float buttonMarginVer = 15;

    public float buttonWidth = 400;
    public float buttonHeight = 74;

    // Etykieta
    public float labelMaringLeft = 700;
    public float labelMaringTop = 35;

    private float labelMargin = 35;

    public float labelWidth = 400;
    public float labelHeight = 54;

    // Sterowanie stronami menu
    private bool pageMain = true;
    private bool pageSettings = false;
    private bool pageAutors = false;
    private bool pageKeys = false;

    // Sterowanie dzwiekiem
    private bool soundOn = true;
    private string soundText;

    void OnGUI() {
        GUI.skin = skin;
        skinText.richText = true;

        if (pageAutors == true || pageSettings == true || pageKeys == true) {
            buttonMaringTop = 30 + labelHeight + labelMargin;
            buttonMaringLeft = 685;

            buttonHeight = 54;
            buttonWidth = 300;

            buttonMargin = 25; 

        } else {
            buttonMaringTop = 216;
            buttonMaringLeft = 710;

            buttonHeight = 74;
            buttonWidth = 400;

            buttonMargin = 35;
        }

        // Główne menu
        if (pageMain == true) {
            if (GUI.Button(new Rect(buttonMaringLeft, buttonMaringTop, buttonWidth, buttonHeight), "Nowa Gra")) {
                //Application.LoadLevel("Intro");
                Application.LoadLevel("Gra");
            }
            if (GUI.Button(new Rect(buttonMaringLeft, buttonMaringTop + buttonHeight + buttonMargin, buttonWidth, buttonHeight), "Ustawienia")) {
                pageMain = false;
                pageSettings = true;
            }
            if (GUI.Button(new Rect(buttonMaringLeft, buttonMaringTop + (buttonHeight + buttonMargin) * 2, buttonWidth, buttonHeight), "O Grze")) {
                pageMain = false;
                pageAutors = true;
            }
            if (GUI.Button(new Rect(buttonMaringLeft, buttonMaringTop + (buttonHeight + buttonMargin) * 3, buttonWidth, buttonHeight), "Wyjscie")) {
                Application.Quit();
            }
        }

        // Ustawienia
        if(pageSettings == true) {
            GUI.Label(new Rect(labelMaringLeft, labelMaringTop, labelWidth, labelHeight), "<size=55>Ustawienia ogolne</size>");

            if (GUI.Button(new Rect(buttonMaringLeft, buttonMaringTop, buttonWidth, buttonHeight), "<size=35>Sterowanie</size>")){
                pageKeys = true;
                pageSettings = false;
            }
            if (GUI.Button(new Rect(buttonMaringLeft, buttonMaringTop + buttonHeight + buttonMargin, buttonWidth, buttonHeight), soundOn ? "<size=35>Dzwieki wlaczone</size>" : "<size=35>Dzwieki wylaczone</size>")) {
                soundOn = !soundOn;
            }
            if (GUI.Button(new Rect(buttonMaringLeft, (buttonMaringTop + (buttonHeight + buttonMargin) * 10) - labelHeight - labelMargin, buttonWidth, buttonHeight), "<size=35>Cofnij</size>")){
                pageMain = true;
                pageSettings = false;
            }
        }

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

        // O autorze i grze
        if (pageAutors == true) {
            GUI.Label(new Rect(labelMaringLeft - 20, labelMaringTop+120, labelWidth, labelHeight), "<size=55>O grze</size>");

            GUI.Label(new Rect(labelMaringLeft - 20, (labelMaringTop + 120) + labelHeight + labelMargin + 25, labelWidth, labelHeight), "<b>Run! Survive! Escape! Zombie ALPHA</b> stworzona", skinText);
            GUI.Label(new Rect(labelMaringLeft - 20, (labelMaringTop + 120) + labelHeight + labelMargin + 50, labelWidth, labelHeight), "na zaliczenie z przedmiotu <b>Programowanie Gier</b>.", skinText);

            GUI.Label(new Rect(labelMaringLeft - 20, (labelMaringTop + 120) + labelHeight + labelMargin + 125, labelWidth, labelHeight), "Do stworzenia tej gry zostal uzyty silnik <b>Unity 5.3.3f Personal</b>.", skinText);

            GUI.Label(new Rect(labelMaringLeft - 20, (labelMaringTop + 120) + labelHeight + labelMargin + 175, labelWidth, labelHeight), "Wszystkie skrypt napisane zostaly w <b>C#</b>. ", skinText);
            GUI.Label(new Rect(labelMaringLeft - 20, (labelMaringTop + 120) + labelHeight + labelMargin + 200, labelWidth, labelHeight), "Grafika po czesci wlasna, a reszta ze strony:", skinText);

            GUI.Label(new Rect(labelMaringLeft - 20, (labelMaringTop + 120) + labelHeight + labelMargin + 225, labelWidth, labelHeight), "<b>http://pl.freeimages.com</b>", skinText);
            GUI.Label(new Rect(labelMaringLeft - 20, (labelMaringTop + 120) + labelHeight + labelMargin + 275, labelWidth, labelHeight), "Gra stworzona przez <b>Daniela \"SzAPKO\" Dudzikowskiego</b>.", skinText);
            GUI.Label(new Rect(labelMaringLeft - 20, (labelMaringTop + 120) + labelHeight + labelMargin + 300, labelWidth, labelHeight), "E-mail kontatkowy: <b>daniel.szapko@gmail.com</b>", skinText);

            GUI.Label(new Rect(labelMaringLeft - 20, (labelMaringTop + 130) + labelHeight + labelMargin + 350, labelWidth, labelHeight), "Rok: <b>2016</b>", skinText);

            if (GUI.Button(new Rect(buttonMaringLeft, (buttonMaringTop + (buttonHeight + buttonMargin) * 10) - labelHeight - labelMargin, buttonWidth, buttonHeight), "<size=35>Cofnij</size>")){
                pageMain = true;
                pageAutors = false;
            }
        }
    }
}
