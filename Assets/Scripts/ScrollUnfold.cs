using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUnfold : MonoBehaviour {
    private OVRGrabbableExtended grabbable;

    private void Awake()
    {
        grabbable = GetComponent<OVRGrabbableExtended>();
        grabbable.OnGrabBegin.AddListener(OnGrabbed);
    }

    public void OnGrabbed()
    {
        Debug.Log("Scroll Grabbed");
    }

    // Use this for initialization
    void Start () {
		
	}
	
    void Unfold()
    {

    }

	// Update is called once per frame
	void Update () {
	}
}
