using UnityEngine;
using System.Collections;

public class playerEquipment : MonoBehaviour {

    private bool inEquipment = false;

    public Texture2D backgroundEquipment;

    // dołączamy kontroler rozgladania się myszka
    private UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController pML;

    void Start () {
        pML = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController>();
    }
	
	void Update () {
        if (pML.setAlive) {
            if (Input.GetKeyUp(KeyCode.Backspace))
            {
                // otwiera i zamyka ekwipunek
                inEquipment = !inEquipment;
            }
        }
    }

    void OnGUI()
    {
        if (inEquipment) {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundEquipment); // tło
        }
    }
}
