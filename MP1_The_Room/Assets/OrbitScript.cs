using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitScript : MonoBehaviour {

    public float orbitSpeed = 1.0f;

    private Vector3 parentPos;

	// Use this for initialization
	void Start () {
        parentPos = transform.parent.position;
	}
	
	// Update is called once per frame
	void Update () {
        transform.RotateAround(parentPos, Vector3.up, orbitSpeed * Time.deltaTime);
	}
}
