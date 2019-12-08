using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuStart : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            Debug.Log("todolist");
            SceneManager.LoadScene("ToDoList");
        }
        else if (OVRInput.GetDown(OVRInput.RawButton.A))
        {
          #if UNITY_EDITOR
                      UnityEditor.EditorApplication.isPlaying = false;
          #else
                            Application.Quit();
          #endif
        }
        else if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            //PlayMode.mode = "Tutorial";
            //SceneManager.LoadScene("CS498HW4");
        }
    }
}
