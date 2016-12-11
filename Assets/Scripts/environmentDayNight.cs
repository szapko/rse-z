using UnityEngine;
using System.Collections;

public class environmentDayNight : MonoBehaviour {

    private float m; // pudełko pomocnicze
   // private float TimeInDays; // który dzień z kolei gry

    public float s = 1.0f; // prędkość

   // public float DayTimeLimit = 10000.0f; // ile trwa jedna doba // jednostka: 

   // public float showTime()
    //{
    //    return TimeInDays;
   // }

    // wymiary
    private int bargroupWidth = 200;
    private int bargroupHeight = 35;
    public int barwidth = 100;
    public int barheight = 30;

   // void Start()
    //{
    //    TimeInDays = 0;
    //}

    // Update is called once per frame
    void Update () {
        m = s * Time.deltaTime;
        transform.Rotate(Vector3.right * m);

        //if (transform.rotation.x == 0)
        //if (Time.deltaTime % DayTimeLimit == 0)
        //{
        //    TimeInDays += 1;
       // }
    }

   // void OnGUI()
   // {
   //         GUI.BeginGroup(new Rect(((Screen.width / 2) - (bargroupWidth / 2)), ((Screen.height / 2) - (bargroupHeight / 2)), bargroupWidth, bargroupHeight));
   //
   //         GUI.Label(new Rect(0, 10, bargroupWidth, bargroupHeight), "Dzień " + TimeInDays);
   //      
   //         GUI.EndGroup();
   // }
}
