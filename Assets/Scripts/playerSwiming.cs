using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(CharacterController))]

public class playerSwiming : MonoBehaviour
{

    private bool _isSwiming;
    private CharacterController m_CharacterController;

    private playerFirstPersonController controller;

    void Start()
    {
        _isSwiming = false;
    }

    public void isSwiming(bool swim)
    {
        _isSwiming = swim;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Gracz")
        {
            controller = other.GetComponent<playerFirstPersonController>();
            Debug.Log("enter");

            controller.GetComponent<playerFirstPersonController>().isSwim = true;

            if (controller.isSwim)
            {
                // mechanizm plywania
                controller.GetComponent<playerFirstPersonController>().setGravity = 0;
                controller.GetComponent<playerFirstPersonController>().setFall = 0;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Gracz")
        {
            controller = other.GetComponent<playerFirstPersonController>();

            m_CharacterController = GetComponent<CharacterController>();

            controller.GetComponent<playerFirstPersonController>().isSwim = false;

            if (m_CharacterController.isGrounded != null)
            {
                controller.GetComponent<playerFirstPersonController>().setGravity = 2;
                controller.GetComponent<playerFirstPersonController>().setFall = 10;
                Debug.Log("left the water");
            }
        }
    }
}