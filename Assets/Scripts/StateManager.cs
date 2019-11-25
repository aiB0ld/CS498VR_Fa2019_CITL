using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
    public int CurrState = 0;
    public GameObject State01;
    public GameObject State02;
    public GameObject State03;
    public Collider stateColl01;
    public Collider stateColl02;
    public Collider stateColl03;

    private List<GameObject> StateList;
    private List<Collider> stateCollList;
    // Use this for initialization
    void Start () {

        Debug.Log("Welcome to Village.");

        //state gameobject initialization
        StateList = new List<GameObject>();
        StateList.Add(State01);
        StateList.Add(State02);
        StateList.Add(State03);
        for( int i = 0; i < 3 ; i++ )
        {
            StateList[i].SetActive(false);
        }
        StateList[CurrState].SetActive(true);

        //state collider initialization
        stateCollList = new List<Collider>();
        stateCollList.Add(stateColl01);
        stateCollList.Add(stateColl02);
        stateCollList.Add(stateColl03);
        for(int i = 0; i < 3; i++)
        {
            stateCollList[i].isTrigger = false;
        }
        stateCollList[0].isTrigger = true;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter(Collider other)
    {
        if (CurrState < 2 && CurrState >= 0)
        {
            Debug.Log( "State Number before Entering:" + CurrState);
            stateCollList[CurrState++].isTrigger = false;
            stateCollList[CurrState].isTrigger = false;
        }
        else if(CurrState == 3)
        {
            Debug.Log("Welcome to the Cave.");
        }
        else
        {
            CurrState = 3;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (CurrState < 3 && CurrState >= 0)
        {
            Debug.Log("Current State Number changes to: " + CurrState);
            StateList[CurrState-1].SetActive(false);
            StateList[CurrState].SetActive(true);
            
        }
    }
}
