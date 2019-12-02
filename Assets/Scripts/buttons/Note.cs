using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
    public GameObject note_button;
    public GameObject realPause;
    public GameObject todolist;
    public GameObject learnobj;
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
            if (note_button.activeInHierarchy)
            {
                note_button.SetActive(false);
            }
            else
            {
                todolist.SetActive(false);
                learnobj.SetActive(false);
                note_button.SetActive(true);
                realPause.SetActive(false);
            }
        }
    }
}
