using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUnfold : MonoBehaviour {
    private OVRGrabbable grabbable;
    public GameObject PauseMenu;
    public GameObject scro;
    public GameObject Done_1;
    static public int grab = 0;
  

    private void Awake()
    {
        grabbable = GetComponent<OVRGrabbable>();
        grabbable.OnGrabBegin.AddListener(OnGrabbed);
    }

    public void OnGrabbed()
    {
        Debug.Log("Scroll Grabbed");
        PauseMenu.SetActive(true);
        scro.SetActive(false);
        // correct sign active
        Done_1.SetActive(true);
        grab = 1;

        
    }

    // Use this for initialization
    void Start () {
		
	}
	
    void Unfold()
    {

    }

	// Update is called once per frame
	void Update () {

	}
}
