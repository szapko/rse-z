using UnityEngine;
using System.Collections;

public class environmentDayNight : MonoBehaviour {
    public float s = 1; // prędkość
    private float m; // pudełko pomocnicze
	
	// Update is called once per frame
	void Update () {
        m = s * Time.deltaTime;
        transform.Rotate(Vector3.right * m);
	}
}
