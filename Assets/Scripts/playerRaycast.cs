using UnityEngine;
using System.Collections;

public class playerRaycast : MonoBehaviour {

    private RaycastHit point;
    private float distance;

    private bool canTake = false;

    private itemAbstract itemAbs;
    private playerEquipment equipment;
    private UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController pFPC;

    void Start()
    {
        equipment = GetComponent<playerEquipment>();
        pFPC = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController>();
    }

    // Update is called once per frame
    void Update() {
        // Debug
        Vector3 fwd = Camera.main.transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(Camera.main.transform.position, fwd, Color.red);

       // Camera.main.transform.position, Camera.main.transform.forward

        if (Physics.Raycast(Camera.main.transform.position, (fwd), out point))
        {
            distance = point.distance;
            //print(distance + " " + point.transform.gameObject.name);
            if (distance <= 5.5 && point.transform.tag == "item")
            {
                canTake = true;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    itemAbstract item = point.transform.gameObject.GetComponent<itemAbstract>();
                    if (item != null)
                    {
                        equipment.addItem(item);
                        Destroy(point.transform.gameObject);
                    }
                }
            }
            else
            {
                canTake = false;
            }
        }
    }

    void OnGUI()
    {
        if(canTake == true)
        {
            GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 100, 120, 25), "Podnieś");
        }
    }
}