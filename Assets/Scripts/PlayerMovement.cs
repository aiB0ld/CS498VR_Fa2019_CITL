using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-0.01f * Input.GetAxis("Vertical"), 0, 0.01f * Input.GetAxis("Horizontal"));
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("on collision with " + collision.collider.name);
    }
}