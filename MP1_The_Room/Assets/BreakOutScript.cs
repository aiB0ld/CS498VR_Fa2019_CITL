using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakOutScript : MonoBehaviour {

    public OVRPlayerController player;
    private Vector3 internalViewpoint;
    private Vector3 externalViewpoint;
    private bool insideRoom;

	// Use this for initialization
	void Start () {
        internalViewpoint = new Vector3(0.0f, 1.0f, 0.0f);
        externalViewpoint = new Vector3(30f, 8.5f, 0f);
        player.transform.position = internalViewpoint;
        insideRoom = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Insert))
        {
            if (insideRoom) {
                player.transform.position = externalViewpoint;
                insideRoom = false;
            } else {
                player.transform.position = internalViewpoint;
                insideRoom = true;
            }
        }
	}
}
