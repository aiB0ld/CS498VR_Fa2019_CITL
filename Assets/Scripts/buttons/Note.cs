using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
    public GameObject notebook;
    public GameObject realPause;
    public GameObject learnObj;
    public GameObject todolist;

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
            if (notebook.activeInHierarchy)
            {
                notebook.SetActive(false);
            }
            else
            {
                learnObj.SetActive(false);
                todolist.SetActive(false);
                notebook.SetActive(true);
                realPause.SetActive(false);
            }
        }
    }
}
