using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reminder : MonoBehaviour {
    public GameObject remind;
    private double timerRemind = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(WaxSealed.sealtouch == 1)
        {
            remind.SetActive(true);
            WaxSealed.sealtouch = 0;
        }
        if (remind.activeInHierarchy)
        {
            timerRemind += Time.deltaTime;
            if (timerRemind >= 4)
            {
                remind.SetActive(false);
                timerRemind = 0;
            }
        }
    }
}
