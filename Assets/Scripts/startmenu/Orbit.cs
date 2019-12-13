using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour {

    private GameObject OrbitCam;
    public GameObject realPause;
    // Use this for initialization
    void Start() {
        OrbitCam = GameObject.Find("island_1119");
        OVRPlayerController.MoveScaleMultiplier = 0;
    }

    // Update is called once per frame
    void Update() {
        OrbitCam.transform.RotateAround(new Vector3(-12.7f, 0.75f, -4.5f), new Vector3(0f, 1f, 0f), 8f * Time.deltaTime);

        if (OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            if (realPause.activeInHierarchy)
            {
                realPause.SetActive(false);
            }
            else {
                realPause.SetActive(true);
            }

        }
    }
}

