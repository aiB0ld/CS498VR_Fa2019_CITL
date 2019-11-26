using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour {
    public static int CurrState = 0;
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
        for(int i = 1; i < 3; i++)
        {
            stateCollList[i].enabled = false;
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter(Collider other)
    {
       // Debug.Log("State Number before Entering:" + CurrState);
        if (other.gameObject.CompareTag("Player"))
        {
            if (CurrState < 2 && CurrState >= 0)
            {
                Debug.Log( "State Number before Entering:" + CurrState);
                CurrState++;
            }
            else if(CurrState == 2)
            {
                CurrState = 3;
                Debug.Log("Welcome to the Cave.");
            }
        }
        
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && CurrState < 3 && CurrState >= 0)
        {
            stateCollList[CurrState-1].enabled = false;
            stateCollList[CurrState].enabled = true;
            Debug.Log("Current State Number changes to: " + CurrState);
            StateList[CurrState-1].SetActive(false);
            StateList[CurrState].SetActive(true);
            
        }
    }
}
