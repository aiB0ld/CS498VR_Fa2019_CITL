using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log(collision.collider.name);
    }

    private void OnCollisionStay(UnityEngine.Collision collision)
    {
        Debug.Log("collision stay");
    }

}
