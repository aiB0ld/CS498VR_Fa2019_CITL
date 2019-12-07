using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Todolist : MonoBehaviour {

    public GameObject todolist;
    public GameObject realPause;
    public GameObject learn;
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
            if (todolist.activeInHierarchy)
            {
                todolist.SetActive(false);
            }
            else
            {
                learn.SetActive(false);
                todolist.SetActive(true);
                realPause.SetActive(false);

            }
        }
    }
}
