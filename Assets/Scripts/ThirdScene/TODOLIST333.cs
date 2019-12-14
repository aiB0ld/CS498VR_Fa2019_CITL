using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TODOLIST333 : MonoBehaviour {

    public GameObject Done_1;
    public GameObject Done_2;
    public GameObject Done_3;

    public AudioClip Npc1Clip;
    public AudioClip Npc2Clip;
    public AudioSource MusicSource;

    private bool check_1 = false;
    private bool check_2 = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (stateManager3.firstNPCEntered)
        {
            if (! check_1)
            {
                MusicSource.clip = Npc1Clip;
                MusicSource.Play();
                check_1 = true;
                //disable movement
                OVRPlayerController.MoveScaleMultiplier = 0;
            }

            if (!MusicSource.isPlaying)
            {
                OVRPlayerController.MoveScaleMultiplier = 1.0f;
                Done_1.SetActive(true);
            }
        }

        if (stateManager3.secondNPCEntered)
        {
            if (!check_2)
            {
                MusicSource.clip = Npc2Clip;
                MusicSource.Play();
                check_2 = true;
                //disable movement
                OVRPlayerController.MoveScaleMultiplier = 0;
            }

            if (!MusicSource.isPlaying)
            {
                OVRPlayerController.MoveScaleMultiplier = 1.0f;
                Done_2.SetActive(true);
            }
        }

        if (stateManager3.CurrState == 3)
        {
            Done_3.SetActive(true);
        }
    }
}
