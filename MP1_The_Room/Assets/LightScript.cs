using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour {

    public Light light;

    // Use this for initialization
    void Start () {
        light = GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("tab"))
        {
            light.color = new Color(255, 0, 0);
        }
	}
}
