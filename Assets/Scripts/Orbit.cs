using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    private GameObject OrbitCam;
	// Use this for initialization
	void Start () {
        OrbitCam = GameObject.Find("OVRCameraRig");
	}
	
	// Update is called once per frame
	void Update () {
        OrbitCam.transform.RotateAround(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f), 8f * Time.deltaTime);
	}
}
