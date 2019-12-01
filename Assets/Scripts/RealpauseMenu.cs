using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealpauseMenu : MonoBehaviour {

    public GameObject realPause;
    public GameObject player;
    private Vector3 origin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            Debug.Log("lalala");
            origin = player.transform.position;
            realPause.transform.position = origin + new Vector3(-1f, 0.0f, 0f);
            realPause.transform.eulerAngles = player.transform.eulerAngles;
            realPause.SetActive(true);
        }
        if (realPause.activeInHierarchy)
        {
            player.transform.position = origin;
        }
    }
}
