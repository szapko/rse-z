using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

[RequireComponent(typeof(CharacterController))]

public class swiming : MonoBehaviour
{

    private bool _isSwiming;
    private CharacterController m_CharacterController;

    private FirstPersonController controller;

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
            controller = other.GetComponent<FirstPersonController>();
            Debug.Log("enter");

            controller.GetComponent<FirstPersonController>().isSwim = true;

            if (controller.isSwim)
            {
                // mechanizm plywania
                controller.GetComponent<FirstPersonController>().setGravity = 0;
                controller.GetComponent<FirstPersonController>().setFall = 0;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "Gracz")
        {
            controller = other.GetComponent<FirstPersonController>();

            m_CharacterController = GetComponent<CharacterController>();

            controller.GetComponent<FirstPersonController>().isSwim = false;

            if (m_CharacterController.isGrounded != null)
            {
                controller.GetComponent<FirstPersonController>().setGravity = 2;
                controller.GetComponent<FirstPersonController>().setFall = 10;
                Debug.Log("left the water");
            }
        }
    }
}