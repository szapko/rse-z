using UnityEngine;
using System.Collections;
//using UnityStandardAssets.Characters.FirstPerson;

public class swiming : MonoBehaviour {

    public Color color;
    bool switchSwiming = false;

    GameObject player;

    //private FirstPersonController firstPersonController;


    void OnTriggerEnter(Collider col) {
        if(col.tag == "Gracz") {
            //firstPersonController = player.GetComponent<FirstPersonController>();
            player = col.gameObject;
            switchSwiming = true;
            swim();
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.tag == "Gracz") {
            switchSwiming = false;
            walk();
        }
    }

    void Update() {
        if(Input.GetKey(KeyCode.Z) && switchSwiming) {

        } else if(!Input.GetKey(KeyCode.Z) && switchSwiming) {

        } else if(Input.GetKey(KeyCode.Q) && switchSwiming) {

        } else if (!Input.GetKey(KeyCode.Q) && switchSwiming) {

        } else {

        }
    } 

    void swim() {
       // player.GetComponent<FirstPersonController>().m_WalkSpeed = 2;
       // player.GetComponent<CharacterMotor>().maxSidewaysSpeed = 2;
       // player.GetComponent<CharacterMotor>().maxBackwardsSpeed = 2;
       // player.GetComponent<CharacterMotor>().maxGroundAcceleration = 2;
       // player.GetComponent<CharacterMotor>().maxAirAcceleration = 2;
        //player.GetComponent<CharacterMotor>().movement.gravity = 1;
        //player.GetComponent<CharacterMotor>().movement.maxFallSpeed = 2;
    }

    void walk() {
       // player.GetComponent<CharacterMotor>().movement.maxForwardSpeed = 6;
       // player.GetComponent<CharacterMotor>().movement.maxSidewaysSpeed = 6;
       // player.GetComponent<CharacterMotor>().movement.maxBackwardsSpeed = 6;
       // player.GetComponent<CharacterMotor>().movement.maxGroundAcceleration = 20;
       // player.GetComponent<CharacterMotor>().movement.maxAirAcceleration = 15;
       // player.GetComponent<CharacterMotor>().movement.gravity = 20;
        ///player.GetComponent<CharacterMotor>().movement.maxFallSpeed = 20;
    }
}
