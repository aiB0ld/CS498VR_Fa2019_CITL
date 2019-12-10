using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class materialChange : MonoBehaviour {
    public Material NewMat;
    public 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(stateManager2.CurrState == 2)
        {
            GetComponent<Renderer>().material = NewMat;
        }
	}
}
