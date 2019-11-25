using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class DisableTrack : MonoBehaviour {

    private GameObject ovrCameraRig;
    private GameObject centerEyeAnchor;
    private Vector3 initialParentPosition;
    private Vector3 fixedPosition;
    private Quaternion initialParentRotation;
    private Quaternion fixedRotation;
    //private bool isPositionTracked = true;
    //private bool isRotationTracked = true;
    // Use this for initialization
    void Start () {
        ovrCameraRig = GameObject.Find("OVRCameraRig");
        centerEyeAnchor = GameObject.Find("CenterEyeAnchor");
        //fixedPosition = centerEyeAnchor.transform.position;
        //fixedRotation = centerEyeAnchor.transform.rotation;
        fixedPosition = centerEyeAnchor.transform.localPosition;
        fixedRotation = centerEyeAnchor.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
        //disable position track
        
        initialParentPosition = ovrCameraRig.transform.parent.position;
        ovrCameraRig.transform.parent.position = centerEyeAnchor.transform.localPosition - fixedPosition;
       
        //disable rotation track
        
        initialParentRotation = ovrCameraRig.transform.rotation;
        ovrCameraRig.transform.rotation = Quaternion.Inverse(centerEyeAnchor.transform.localRotation * Quaternion.Inverse(fixedRotation));
    }
}
