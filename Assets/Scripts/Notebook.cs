using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour {

    // Use this for initialization
    //public float speed = 5f;
    public GameObject Book;
    public GameObject Light;
    public static bool BookisGrabbed = false;

    private OVRGrabbable grabbable;
    void Start () {
        Book.SetActive(false);
        Light.SetActive(false);
	}
    private void Awake()
    {
        grabbable = GetComponent<OVRGrabbable>();
        grabbable.onBookGrabBegin.AddListener(onGrabbed);
    }

    public void onGrabbed()
    {
        Debug.Log("Notebook Grabbed");
        BookisGrabbed = true;
    }

    // Update is called once per frame
    void Update () {
        //RockMove();
        transform.Rotate(0, 1, 0);
        if(StateManager.CurrState == 1)
        {
            
            Book.SetActive(true);
            Light.SetActive(true);
        }
        else if(BookisGrabbed)
        {
            Book.SetActive(false);
        }
        
	}

}
