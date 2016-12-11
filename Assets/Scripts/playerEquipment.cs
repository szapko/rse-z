using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class playerEquipment : MonoBehaviour {

    private bool openEquipment;

    public Texture2D backgroundEquipment;

    // wygląd inwentarza
    public int rows = 5; // kolumny na przedmioty w jednym wierszu
    public int boxWidth = 50;
    public int boxHeight = 50;
    public int boxMargin = 10;
    public Rect positionInventory = new Rect(20, 20, 0, 0);

    // Lista przedmiotów
    private List<itemAbstract> listOfItems = new List<itemAbstract>();

    // dołączamy kontroler rozgladania się myszka
    private UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController pML;

    // odwołanie do statystyk
    private playerStatistics pS;

    private playerRaycast pRay;

    // odwołanie do menu pauzy
    private pauseMenu pM;

    void Start () {
        openEquipment = false;
        pML = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController>();
        pS = gameObject.GetComponent<playerStatistics>();
        pM = gameObject.GetComponent<pauseMenu>();
        pRay = gameObject.GetComponent<playerRaycast>();

        positionInventory = new Rect(positionInventory.x, positionInventory.y, ((rows * boxWidth) + ((rows + 1) * boxMargin)), ((rows * boxHeight) + ((rows + 1) * boxMargin)));
    }
	
	void Update () {
        if (pML.setAlive) {
            if (Input.GetKeyUp(KeyCode.Backspace))
            {
                // otwiera i zamyka ekwipunek
                openEquipment = !openEquipment;
            }
        }
    }

    void OnGUI()
    {
        if(!pM.pausedInfo())
        {
            if (openEquipment)
            {
                //GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundEquipment); // tło

                int allOfItems = listOfItems.Count; // ilość przedmitów
                int rowsTab = Mathf.CeilToInt(allOfItems / rows) + 1;

                GUILayout.BeginArea(positionInventory);
                // rysujemy kafelki na przedmioty
                for (int i = 0; i < rowsTab; i++)
                {
                    for (int j = 0; j < rows; j++)
                    {
                        if ((i * rowsTab) + j < allOfItems)
                        {
                            if (GUI.Button(new Rect((boxMargin + boxMargin * j + boxWidth * j), (boxMargin + boxMargin * i + boxHeight * i), boxWidth, boxHeight), listOfItems[(i * rows) + j].getIcon())) // getItemIcon zwraca obiekt typu Texture2D
                            {
                                bool disposable = listOfItems[(i * rows) + j].execute(pS); // funkcja execute pozwala na wpływanie na wszystko we wskazanym obiekcie. np. zmiana punktow zycia lub pancerz
                                if (disposable)
                                {
                                    listOfItems.RemoveAt((i * rows) + j); // usuwa obiekt o konkretnym indeksie
                                }
                            }
                        }
                        else
                        {
                            if (GUI.Button(new Rect((boxMargin + boxMargin * j + boxWidth * j), (boxMargin + boxMargin * i + boxHeight * i), boxWidth, boxHeight), ""))
                            {
                                Debug.Log("Clicked the button!");
                            }
                        }
                    }
                }
                GUILayout.EndArea();
            }
        }
    }

    public void addItem(itemAbstract item)
    {
        listOfItems.Add(item);
    }
}
