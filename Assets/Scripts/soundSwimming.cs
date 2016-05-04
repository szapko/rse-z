using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class soundSwimming : MonoBehaviour
{

    public CharacterController characterControler;

    public AudioSource sciezka;
    // Dźwięk pływania
    public AudioClip soundSwiming;
    public float kroki = 0f;
    public float czasKroku = 0.5f;

    public bool graczNaZiemi;
    private playerFirstPersonController controller;

    // Use this for initialization
    void Start()
    {
        controller = GetComponent<playerFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (sciezka != null) soundSwim();
    }

    private void soundSwim()
    {
        if (kroki > 0)
        {
                kroki -= Time.deltaTime;
        }

        if (!characterControler.isGrounded && kroki <= 0 && controller.isSwim)
        {
            kroki = czasKroku;
            sciezka.PlayOneShot(soundSwiming);
        }
    }
}
