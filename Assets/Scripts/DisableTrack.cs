using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class DisableTrack : MonoBehaviour {

    private GameObject ovrCameraRig;
    private GameObject centerEyeAnchor;
    private Vector3 fixedPosition;
    private Quaternion fixedRotation;
    //private bool isPositionTracked = true;
    //private bool isRotationTracked = true;
    // Use this for initialization
    void Start () {
        ovrCameraRig = GameObject.Find("OVRCameraRig");
        centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        fixedRotation = centerEyeAnchor.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
       
        //disable rotation track
        ovrCameraRig.transform.rotation = Quaternion.Inverse(centerEyeAnchor.transform.localRotation * Quaternion.Inverse(fixedRotation));
    }
}
