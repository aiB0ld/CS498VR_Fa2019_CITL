using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    public GameObject mapmap;
    public GameObject realPause;
    public GameObject todolist;
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
            if (mapmap.activeInHierarchy)
            {
                mapmap.SetActive(false);
            }
            else
            {
                todolist.SetActive(false);
                learnobj.SetActive(false);
                mapmap.SetActive(true);
                realPause.SetActive(false);
            }
        }
    }
}