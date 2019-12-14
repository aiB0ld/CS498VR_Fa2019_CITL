using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuRockGrab : MonoBehaviour
{
    public float grabBegin = 0.05f;
    public float grabEnd = 0.05f;
    private float l_prevFlex;
    private float r_prevFlex;
    private float l_flex;
    private float r_flex;

    private bool CheckForGrabOrRelease(float flex, float prevFlex)
    {
        if ((flex >= grabBegin) && (prevFlex < grabBegin))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        l_prevFlex = l_flex;
        l_flex = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.LTouch);
        r_prevFlex = r_flex;
        r_flex = OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger, OVRInput.Controller.RTouch);
    }

    private void OnTriggerStay(Collider other)
    {
        if (CheckForGrabOrRelease(l_flex, l_prevFlex) || CheckForGrabOrRelease(r_flex, r_prevFlex))
        {
            StartMenuPlayerController.isGrabbed = true;
        }
    }
}
