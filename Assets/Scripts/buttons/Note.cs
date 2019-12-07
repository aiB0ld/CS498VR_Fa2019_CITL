using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour {
    public GameObject mapmap;
    public GameObject realPause;

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
            if (mapmap.activeInHierarchy)
            {
                mapmap.SetActive(false);
            }
            else
            {
                mapmap.SetActive(true);
                realPause.SetActive(false);
            }
        }
    }
}
