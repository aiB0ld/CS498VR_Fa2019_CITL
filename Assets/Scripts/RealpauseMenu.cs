using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealpauseMenu : MonoBehaviour {

    public GameObject realPause;
    public GameObject player;
    public GameObject note_button;
    public GameObject learnobj;
    public GameObject todolist;
    private double timer111 = 0;
    private double timer222 = 0;
    private double timer333 = 0;
    // public GameObject centereye;
    //private Vector3 origin;
    private Vector3 origin111;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.RawButton.X) && TODOLIST.lecture == 0)
        {
            if (realPause.activeInHierarchy)
            {
                realPause.SetActive(false);
            } else
            {
                //origin = centereye.transform.position;
                origin111 = player.transform.position;
                //realPause.transform.position = origin + new Vector3(-1f, 0.0f, 0f);
                //realPause.transform.eulerAngles = player.transform.eulerAngles;
                //realPause.transform.RotateAround(origin, new Vector3(0f, 1f, 0f), player.transform.eulerAngles.);
                realPause.SetActive(true);
            }
        }
        if (realPause.activeInHierarchy)
        {
            player.transform.position = origin111;
        }
        //learning object
        if (learnobj.activeInHierarchy)
        {
            timer111 += Time.deltaTime;
            if (timer111 >= 4)
            {
                learnobj.SetActive(false);
                timer111 = 0;
            }
        }
        //todolist
        if (todolist.activeInHierarchy)
        {
            timer222 += Time.deltaTime;
            if (timer222 >= 4)
            {
                todolist.SetActive(false);
                timer222 = 0;
            }
        }
        //todolist
        if (note_button.activeInHierarchy)
        {
            timer333 += Time.deltaTime;
            if (timer333 >= 4)
            {
                note_button.SetActive(false);
                timer333 = 0;
            }
        }

    }
}
