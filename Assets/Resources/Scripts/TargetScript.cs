using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetScript : MonoBehaviour {

    private bool isShooted_1;
    private bool isShooted_2;
    private bool isShooted_3;
    private bool isShooted_4;
    private bool isShooted_5;
    private float timer_1 = 0.0f;
    private float timer_2 = 0.0f;
    private float timer_3 = 0.0f;
    private float timer_4 = 0.0f;
    private float timer_5 = 0.0f;
    public GameObject target_1;
    public GameObject target_2;
    public GameObject target_3;
    public GameObject target_4;
    public GameObject target_5;
    public Text scoreBoard;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isShooted_1)
        {
            timer_1 += Time.deltaTime;
            if(timer_1 > 5.0f)
            {
                target_1.SetActive(true);
                target_1.transform.position = new Vector3(-731f, 660f, 221f);
                target_1.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                timer_1 = 0.0f;
                isShooted_1 = false;
            }
        }
        if (isShooted_2)
        {
            timer_2 += Time.deltaTime;
            if (timer_2 > 5.0f)
            {
                target_2.SetActive(true);
                target_2.transform.position = new Vector3(-81f, 460f, 368f);
                target_2.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                timer_2 = 0.0f;
                isShooted_2 = false;
            }
        }
        if (isShooted_3)
        {
            timer_3 += Time.deltaTime;
            if (timer_3 > 5.0f)
            {
                target_3.SetActive(true);
                target_3.transform.position = new Vector3(368f, 760f, 418f);
                target_3.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                timer_3 = 0.0f;
                isShooted_3 = false;
            }
        }
        if (isShooted_4)
        {
            timer_4 += Time.deltaTime;
            if (timer_4 > 5.0f)
            {
                target_4.SetActive(true);
                target_4.transform.position = new Vector3(-231f, 1060f, 428f);
                target_4.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                timer_4 = 0.0f;
                isShooted_4 = false;
            }
        }
        if (isShooted_5)
        {
            timer_5 += Time.deltaTime;
            if (timer_5 > 5.0f)
            {
                target_5.SetActive(true);
                target_5.transform.position = new Vector3(-131f, 660f, 288f);
                target_5.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
                timer_5 = 0.0f;
                isShooted_5 = false;
            }
        }
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.collider.name == "Target_1")
        {
            target_1.SetActive(false);
            isShooted_1 = true;
            UpdateScore();
        }
        if (collision.collider.name == "Target_2")
        {
            target_2.SetActive(false);
            isShooted_2 = true;
            UpdateScore();
        }
        if (collision.collider.name == "Target_3")
        {
            target_3.SetActive(false);
            isShooted_3 = true;
            UpdateScore();
        }
        if (collision.collider.name == "Target_4")
        {
            target_4.SetActive(false);
            isShooted_4 = true;
            UpdateScore();
        }
        if (collision.collider.name == "Target_5")
        {
            target_5.SetActive(false);
            isShooted_5 = true;
            UpdateScore();
        }
    }

    private void UpdateScore()
    {
        int currentScore = int.Parse(scoreBoard.text.Substring(7));
        scoreBoard.text = "Score: " + (currentScore + 1).ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Target_1")
        {
            target_1.SetActive(false);
            isShooted_1 = true;
            UpdateScore();
        }
        if (other.gameObject.name == "Target_2")
        {
            target_2.SetActive(false);
            isShooted_2 = true;
            UpdateScore();
        }
        if (other.gameObject.name == "Target_3")
        {
            target_3.SetActive(false);
            isShooted_3 = true;
            UpdateScore();
        }
        if (other.gameObject.name == "Target_4")
        {
            target_4.SetActive(false);
            isShooted_4 = true;
            UpdateScore();
        }
        if (other.gameObject.name == "Target_5")
        {
            target_5.SetActive(false);
            isShooted_5 = true;
            UpdateScore();
        }
    }
}
