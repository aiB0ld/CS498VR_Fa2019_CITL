using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeDetection : MonoBehaviour {

    private float Xorigin = 15.2f;
    private float Zorigin = 0.27f;
    private float Height = 4.3f;
    private Vector3 OriRotation = new Vector3(0, 270, 0);
    public GameObject RangeWarning;

    private double timer = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (transform.position.y < 3f)
        {
            transform.position = new Vector3(Xorigin, Height, Zorigin);
            transform.rotation = Quaternion.Euler(OriRotation.x, OriRotation.y, OriRotation.z);
            RangeWarning.SetActive(true);
            timer = 0f;
        }
        if(RangeWarning.activeInHierarchy && timer > 2f)
        {
            RangeWarning.SetActive(false);
        }
    }
}
