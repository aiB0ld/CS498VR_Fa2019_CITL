using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notebook : MonoBehaviour {

    // Use this for initialization
    //public float speed = 5f;
    public GameObject Book;
    public GameObject Light;
    public GameObject notebook;
    public static bool BookisGrabbed = false;
    static public int grabnote = 0;
    public GameObject Done2;

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
        notebook.SetActive(true);
        grabnote = 1;
        Done2.SetActive(true);

    }

    // Update is called once per frame
    void Update () {
        //RockMove();
        transform.Rotate(0, 1, 0);
        if(stateManager2.CurrState == 1)
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
