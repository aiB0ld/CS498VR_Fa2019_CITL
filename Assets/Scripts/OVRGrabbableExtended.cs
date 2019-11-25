using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OVRGrabbableExtended : OVRGrabbable {
    public UnityEvent OnGrabBegin;

    /*
    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        Debug.Log("Grab Begin");
        OnGrabBegin.Invoke();
        base.GrabBegin(hand, grabPoint);
        
    }
    **/
    override public void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        Debug.Log("Grab Begin");
        base.GrabBegin(hand, grabPoint);
    }
}
