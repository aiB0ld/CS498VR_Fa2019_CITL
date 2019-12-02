using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUnfold : MonoBehaviour {
    private OVRGrabbable grabbable;
    public GameObject PauseMenu;
    public GameObject scro;
    public GameObject Done_1;
    public GameObject learnobj;
    static public int grab = 0;
    private double timer111 = 0;


    private void Awake()
    {
        grabbable = GetComponent<OVRGrabbable>();
        grabbable.OnGrabBegin.AddListener(OnGrabbed);
    }

    public void OnGrabbed()
    {
        Debug.Log("Scroll Grabbed");
        learnobj.SetActive(false);
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
        if (PauseMenu.activeInHierarchy)
        {
            timer111 += Time.deltaTime;
            if (timer111 >= 4)
            {
                PauseMenu.SetActive(false);
                timer111 = 0;
            }
        }
    }
}
