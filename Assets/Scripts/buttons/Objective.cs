using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{


    //public GameObject target_1;
    public GameObject learnobj;
    public GameObject realPause;
    public GameObject note_button;
    public GameObject todolist;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            if (learnobj.activeInHierarchy)
            {
                learnobj.SetActive(false);
            } else
            {
                note_button.SetActive(false);
                todolist.SetActive(false);
                learnobj.SetActive(true);
                realPause.SetActive(false);
            }
        }
    }
}
