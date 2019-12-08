using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaxSealed : MonoBehaviour {
    public UnityEvent onLidGrabBegin;
    static public int sealtouch = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            Debug.Log("DISPLAY WAX SEALED MESSAGE!");
            LidInspector.OriGrabbed = true;
            sealtouch = 1;
        }
    }
}
