using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUnfold : MonoBehaviour {
    private OVRGrabbable grabbable;
    public GameObject PauseMenu;
    public GameObject scro;

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
