using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    private GameObject OrbitCam;
	// Use this for initialization
	void Start () {
        OrbitCam = GameObject.Find("island_1119");
	}
	
	// Update is called once per frame
	void Update () {
        OrbitCam.transform.RotateAround(new Vector3(-12.7f, 0.75f, -4.5f), new Vector3(0f, 1f, 0f), 8f * Time.deltaTime);
	}
}
