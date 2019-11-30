using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    private GameObject Bullet;
    private Vector3 spawnPosition;
    private Quaternion spawnRotation;
    // public Transform SpawnPoint;
    private GameObject spitfire;

    private AudioClip MusicClip_Shooting;
    private AudioSource MusicSource;

    // Use this for initialization
    void Start () {
        Bullet = GameObject.Find("Bullet");
        spitfire = GameObject.Find("Super_Spitfire");
        MusicSource = GetComponent<AudioSource>();
        MusicClip_Shooting = Resources.Load<AudioClip>("Sounds/Shooting");
    }
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.GetDown(OVRInput.RawButton.X))
        {
            MusicSource.clip = MusicClip_Shooting;
            MusicSource.Play(0);
            // spawnPosition = spitfire.transform.position + Vector3.Project(new Vector3(0, 1.8f, 12), spitfire.transform.forward);
            spawnPosition = spitfire.transform.position;
            spawnRotation = spitfire.transform.rotation;

            GameObject bullet = GameObject.Instantiate(Bullet, spawnPosition, spawnRotation);

            if (bullet.transform.forward != spitfire.transform.forward)
            {
                Debug.Log("Forward mismatch");
            }
            // bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * 150); 
            bullet.GetComponent<Rigidbody>().velocity = spitfire.transform.forward * 400;
            // bullet.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 100f);
            Destroy(bullet, 350f);
        }
    }
}
