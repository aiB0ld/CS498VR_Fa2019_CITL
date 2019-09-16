using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderScript : MonoBehaviour {

    public bool entered = false;
    public bool stay = true;
    public GameObject sphere_3;
    public float fallSpeed = 5.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (entered)
        {
            sphere_3.transform.Translate(Vector3.down * fallSpeed * Time.deltaTime, Space.World);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        entered = true;
        Debug.Log("entered");
    }

    private void OnTriggerStay(Collider other)
    {
        if (stay)
        {
            Debug.Log("staying");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        entered = false;
        Debug.Log("exit");
    }
}
