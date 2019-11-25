using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OVRGrabbableExtended : OVRGrabbable {
    public UnityEvent OnGrabBegin;

    public override void GrabBegin(OVRGrabber hand, Collider grabPoint)
    {
        base.GrabBegin(hand, grabPoint);
        OnGrabBegin.Invoke();
    }
}
