using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pausemenu;
    public GameObject map;
	// Use this for initialization
	void Start () {
        pausemenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (pausemenu.activeInHierarchy == true && OVRInput.Get(OVRInput.RawButton.B))
        {   
            pausemenu.SetActive(false);
            Debug.Log("MUNE false");
        }
        else if (pausemenu.activeInHierarchy == false && OVRInput.Get(OVRInput.RawButton.B))
        {
            pausemenu.SetActive(true);
            Debug.Log("MUNE true");
        }
        else if (pausemenu.activeInHierarchy == true && OVRInput.Get(OVRInput.RawButton.A))
        {
            //SceneManager.LoadScene("StartMenu");
        }
        else if (pausemenu.activeInHierarchy == true && OVRInput.Get(OVRInput.RawButton.Y))
        {   
            if(map.activeInHierarchy == true)
            {
                map.SetActive(false);
            }
            else
            {
                map.SetActive(true);
            }
            
        }
    }
}
