using UnityEngine;
using System.Collections;

public class playerStatistics : MonoBehaviour {

    private float maxHealth = 100;
    private float currentHealth = 100;
    private float maxHunger = 100;
    private float currentHunger = 100;
    private float maxStamina = 100;
    private float currentStamina = 100;

    private float barWidth;
    private float barHeight;

    public Texture2D healthTexture;
    public Texture2D hungerTexture;
    public Texture2D staminaTexture;

    private CharacterController chCont;
    private UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController fpsC;

    private Vector3 lastPosition;
    private float walkSpeed;
    private float runSpeed;

    private float canRegenerate = 0.0f;
    private float canHeal = 0.0f;

    // Efekt obrazen
    public Texture2D bloodTexture;
    public Texture2D redTexture;
    public Texture2D bloodRingTexture;
    private bool hit = false;
    private float aplha = 0.0f;
    // efekt obrazen

    // Komunikaty
    public GUIStyle skinTextCom;
    // komunikaty

    void Awake() {
        barHeight = Screen.height * 0.02f;
        barWidth = barHeight * 10.0f;

        chCont = GetComponent<CharacterController>();
        fpsC = gameObject.GetComponent<UnityStandardAssets.Characters.FirstPerson.playerFirstPersonController>();

        lastPosition = transform.position;
    }

    void OnGUI() {
        GUI.DrawTexture(new Rect(Screen.width - barWidth - 10,
                                 Screen.height - barHeight - 3,
                                 currentHealth * barWidth / maxHealth,
                                 barHeight),
                        healthTexture);
        GUI.DrawTexture(new Rect(Screen.width - barWidth - 10,
                                 Screen.height - barHeight * 2 - 6,
                                 currentHunger * barWidth / maxHunger,
                                 barHeight),
                        hungerTexture);
        GUI.DrawTexture(new Rect(Screen.width - barWidth - 10,
                                 Screen.height - barHeight * 3 - 9,
                                 currentStamina * barWidth / maxStamina,
                                 barHeight),
                        staminaTexture);

        // Efekt obrazen
        if (hit)
        {
            GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, aplha);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), bloodRingTexture, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), redTexture, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(50, 100, Screen.width / 0.5f, Screen.height / 0.5f), bloodTexture, ScaleMode.ScaleToFit);
            GUI.DrawTexture(new Rect(-1000, 100, Screen.width / 0.5f, Screen.height / 0.5f), bloodTexture, ScaleMode.ScaleToFit);
            StartCoroutine("chanegerOpacity");
        }

        if (aplha <= 0.0f)
        {
            hit = false;
        }
        // efekt obrazen

        // Komunikaty
        skinTextCom.richText = true;
        if (currentHealth <= 0.0f) {
            if (currentHunger <= 0.0f) {
                GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "UMARLES \nZ \nGLODU", skinTextCom);
            } else
            {
                GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "ZGINALES!", skinTextCom);
            }
            
            Destroy(fpsC, 0.1F); // niszczymy gracza
            fpsC.setAlive = false;
        } 
        // komunikaty
    }

    void FixedUpdate() {
        float speed = walkSpeed;

        // zuzycie staminy
        if ((chCont.isGrounded || fpsC.isSwim) && Input.GetKey(KeyCode.LeftShift) && lastPosition != transform.position && currentStamina > 0)
        {
            lastPosition = transform.position;
            speed = runSpeed;
            currentStamina -= 0.07f;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            canRegenerate = 6.0f; // czas oczekiwania na start regeneracji
        }

        // unimozliwienie biegania
        if (currentStamina > 0)
        {
            fpsC.CanRun = true;
        }
        else {
            fpsC.CanRun = false;
        }

    }

    void Update() {
        // testowanie zadawania obrazen
        if (Input.GetKeyDown(KeyCode.P))
        {
            takeDamage(30);
            // Efekt obrazen
            hit = true;
            aplha = 0.5f;
            // efekt obrazen
        }

        if (canHeal > 0.0f)
        {
            canHeal -= Time.deltaTime;
        }
        if (canRegenerate > 0.0f)
        {
            canRegenerate -= Time.deltaTime;
        }

        // regenracja zycia i wyrzymalosci
       /* if (canHeal <= 0.0f && currentHealth < maxHealth)
        {
            regenerate(ref currentHealth, maxHealth);
        }*/
        if (canRegenerate <= 0.0f && currentStamina < maxStamina)
        {
            regenerate(ref currentStamina, maxStamina);
        }

        // Efekt głodu
        currentHunger -= Time.deltaTime*0.01f; // wartosc domyslna
        //currentHunger -= Time.deltaTime * 10.0f; // dod testow
        currentHunger = Mathf.Clamp(currentHunger, 0, maxHunger);

        // zabiera zycie gdy jestes glodny
        if (currentHunger == 0.0f && currentHealth >= 0.0f)
        {
            currentHealth -= Time.deltaTime * 0.3f; // wartosc domyslna
            //currentHealth -= Time.deltaTime * 10.0f; // do testow
        }

    }

    void takeDamage(float damage) {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (currentHealth < maxHealth)
        { 
            canHeal = 5.0f;
        }
    }

    void regenerate(ref float currentStat, float maxStat)
    {
        currentStat += maxStat * 0.0025f;
        Mathf.Clamp(currentStat, 0, maxStat);
    }

    IEnumerator chanegerOpacity()
    {
        yield return new WaitForEndOfFrame();
        aplha -= 0.03f;
    }
}
