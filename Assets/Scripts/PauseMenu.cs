using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pausemenu;
    public GameObject map;

    public GameObject Done_1;
    public GameObject Done_2;
    public GameObject Done_3;
    // Use this for initialization
    void Start () {
        pausemenu.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (pausemenu.activeInHierarchy == true && OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            pausemenu.SetActive(false);
            Debug.Log("Menu false");
        }
        else if (pausemenu.activeInHierarchy == false && OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            pausemenu.SetActive(true);
            Debug.Log("Menu true");
        }
        else if (pausemenu.activeInHierarchy == true && OVRInput.GetDown(OVRInput.RawButton.A))
        {
            //SceneManager.LoadScene("StartMenu");
        }
        else if (pausemenu.activeInHierarchy == true && OVRInput.GetDown(OVRInput.RawButton.Y))
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

        if(StateManager.CurrState == 1)
        {
            Done_1.SetActive(true);
        }
        else if(StateManager.CurrState == 2)
        {
            Done_2.SetActive(true);
        }
        else if(StateManager.CurrState == 3)
        {
            Done_3.SetActive(true);
        }
    }

}
