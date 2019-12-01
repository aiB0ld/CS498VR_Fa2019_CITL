using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Objective : MonoBehaviour
{


    //public GameObject target_1;
    public GameObject learnobj;
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
                learnobj.SetActive(true);
            }
        }
    }
}
