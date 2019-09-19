using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

    public Light light;
    private Color OrigiColor;
    private int Count;
    
    // Use this for initialization
    void Start () {
        light = GetComponent<Light>();
        Count = 0;
        OrigiColor = light.color;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("tab"))
        {   
            Count = Count + 1;
        }
        
        if(Count % 4 == 1) {
            light.color = new Color(255, 0, 0);
        } else if(Count % 4 == 2) {
            light.color = new Color(100, 0, 100);
        } else if(Count % 4 == 3) {
            light.color = new Color(10, 2, 200);
        } else
        {
            light.color = OrigiColor;
        }
	}
}
