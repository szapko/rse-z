using UnityEngine;
using System.Collections;

public class PlayerStats : MonoBehaviour {

    private float maxHealth = 100;
    private float currentHealth = 100;
    //private float maxArmour = 100;
    //private float currentArmour = 100;
    private float maxStamina = 100;
    private float currentStamina = 100;

    private float barWidth;
    private float barHeight;

    public Texture2D healthTexture;
    //public Texture2D armourTexture;
    public Texture2D staminaTexture;

    private CharacterController chCont;
    private UnityStandardAssets.Characters.FirstPerson.FirstPersonController fpsC;

    private Vector3 lastPosition;
    private float walkSpeed;
    private float runSpeed;
    private float canRegenerate;




    void Awake() {
        barHeight = Screen.height * 0.02f;
        barWidth = barHeight * 10.0f;

        chCont = GetComponent<CharacterController>();
        fpsC = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>();

        lastPosition = transform.position;
    }

    void OnGUI() {
        GUI.DrawTexture(new Rect(Screen.width - barWidth - 10,
                                 Screen.height - barHeight - 10,
                                 currentHealth * barWidth / maxHealth,
                                 barHeight),
                        healthTexture);
       // GUI.DrawTexture(new Rect(Screen.width - barWidth - 10,
        //                         Screen.height - barHeight * 2 - 20,
       //                          currentArmour * barWidth / maxArmour,
        //                         barHeight),
        //                armourTexture);
        GUI.DrawTexture(new Rect(Screen.width - barWidth - 10,
                                 Screen.height - barHeight * 2 - 20,
                                 currentStamina * barWidth / maxStamina,
                                 barHeight),
                        staminaTexture);
    }

    void FixedUpdate() {
        float speed = walkSpeed;

        // Wytrzymalosc
        if (chCont.isGrounded && Input.GetKey(KeyCode.LeftShift) && lastPosition != transform.position && currentStamina > 0)
        {
            lastPosition = transform.position;
            speed = runSpeed;
            currentStamina -= 1;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            canRegenerate = 5.0f;
        }

        if (currentStamina > 0)
        {
            fpsC.CanRun = true;
        }
        else {
            fpsC.CanRun = false;
        }

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.P))
        {
            takeDamage(30);
        }
    }

    void takeDamage(float damage) {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

}
