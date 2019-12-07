using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraSwitch : MonoBehaviour {
    public GameObject FirstPersonVP;
    public GameObject ThirdPersonVP;
    bool isFirstPersonVP;

    public GameObject cam;
    //public Vector3 firstPersonCamPosition;
    //public Vector3 thirdPersonCamPosition;

	// Use this for initialization
	void Start () {
        isFirstPersonVP = false;

        //firstPersonCamPosition = new Vector3(0, 0, 0.5f);
        //thirdPersonCamPosition = new Vector3(0.13f, 0.87f, -0.84f);

        //ThirdPersonVP.SetActive(!isFirstPersonVP);
        //FirstPersonVP.SetActive(isFirstPersonVP);
	}
	
    void SwitchView()
    {
        isFirstPersonVP = !isFirstPersonVP;
        /**
       
        if (isFirstPersonVP)
        {
            cam.transform.localPosition = firstPersonCamPosition;
            cam.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
           
        else cam.transform.localPosition = thirdPersonCamPosition;
    **/

        ThirdPersonVP.SetActive(!isFirstPersonVP);
        FirstPersonVP.SetActive(isFirstPersonVP);
    }
    
    void DisableMovement()
    {

    }
    
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("x")) SwitchView();

        if (isFirstPersonVP) DisableMovement();
	}
}
