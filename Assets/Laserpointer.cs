using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Laserpointer : MonoBehaviour {

    public GameObject player;
    public static GameObject currentObject;
    int currentID;
	// Use this for initialization
	void Start () {
        currentObject = null;
        currentID = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Ray ray = new Ray(player.transform.position, player.transform.forward);
        //sends out a Raycast and returns an array filled with everything it hit
        RaycastHit[] hits;
        hits = Physics.RaycastAll(player.transform.position, player.transform.TransformDirection(Vector3.forward), 100.0F);
        Debug.DrawRay(player.transform.position, player.transform.TransformDirection(Vector3.forward) * 10, Color.yellow);
        //go through all the hit objects and checks if any of them were our button
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];

            //us the object id(??) to determine if have already run the code for this object
            int id = hit.collider.gameObject.GetInstanceID();

            //if have not
            if (currentID != id)
            {
                currentID = id;
                currentObject = hit.collider.gameObject;

                //checks based of the tag
                string tag = currentObject.tag;
                
                //start button
                if (tag == "Start" && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                {
                    Debug.Log("HIT Strat");
                    StartLecture();
                }
                else if (tag == "Quit" && OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger))
                {
                    Debug.Log("HIT Quit");
                    QuitLecture();
                }
            }
        }
	}

    public void StartLecture()
    {
        Debug.Log("Starting Lecture...");
        //SceneManager.LoadScene("");
    }

    public void QuitLecture()
    {
        Debug.Log("Quiting Lecture...");
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}
