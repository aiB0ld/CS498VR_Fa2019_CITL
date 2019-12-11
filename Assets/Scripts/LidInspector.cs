using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LidInspector : MonoBehaviour
{
    public static bool OriGrabbed;
    public static bool OneGrabbed;
    public static bool TwoGrabbed;
    public static bool ThreeGrabbed;

    public GameObject urn;

    public static UnityEvent OnLidAllInspected;
    //public OVRGrabbable grabbable;

    // Use this for initialization
    void Start()
    {
        OriGrabbed = false;
        OneGrabbed = false;
        TwoGrabbed = false;
        ThreeGrabbed = false;

    }

    private void Awake()
    {
        LidClose lidCloseDetector = urn.GetComponent<LidClose>();
        lidCloseDetector.onLidOpened.AddListener(OnLidGrabbed);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnLidGrabbed()
    {
        Debug.Log("Lid Inspector: grabbed " + this.name);
        //ChangeParent();
        if (this.name == "Lid_One_1126")
        {
            OneGrabbed = true;
        }
        else if (this.name == "Lid_Two_1128")
        {
            TwoGrabbed = true;
        }
        else if (this.name == "Lid_Three_1128")
        {
            ThreeGrabbed = true;
        }
    }
}