using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TODOLIST : MonoBehaviour
{

    public GameObject note;
    public GameObject note2;
    public GameObject Done_1;
    public GameObject Done_3;
    static public int lecture = 0;
    private double start_time = 0;
    private double timer = 0;
    private int flag = 0;
    private bool check_1 = false;
    private bool check_2 = false;

    private bool check_todo = false;
    private bool check_ceal = false;
    private bool check_note = false;

    private float timer_note = 0;
    public GameObject urnCanves;

    public AudioClip UrnClip;
    public AudioClip NoteClip;
    public AudioSource MusicSource_cave;

    public GameObject todocaveReminder;
    public GameObject findnoteReminder;
    private bool notereminderisopen = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Time.realtimeSinceStartup - StateManager.cave_timer >= 10)
        {
            todocaveReminder.SetActive(false);
        }
        else if (Time.realtimeSinceStartup - StateManager.cave_timer >= 1)
        {
            if (! check_todo)
            {
                todocaveReminder.SetActive(true);
                check_todo = true;
            }
        }

        if (stateManager2.CurrState == 0 && stateManager2.isInStateOne)
        {
            urnCanves.SetActive(true);
            OVRPlayerController.MoveScaleMultiplier = 0;
            if (!check_1)
            {
                lecture = 1;
                MusicSource_cave.Play();
                check_1 = true;
            }
            if (! MusicSource_cave.isPlaying)
            {
                OVRPlayerController.MoveScaleMultiplier = 0.6f;
                lecture = 0;
            }
        }
        else if(stateManager2.CurrState == 1)
        {
            Done_1.SetActive(true);
            urnCanves.SetActive(false);
            notereminderisopen = true;
            if (timer_note < 10 && timer_note > 6 && ! check_note)
            {
                findnoteReminder.SetActive(true);
                check_note = true;
            }
            
            timer_note += Time.deltaTime;
            if(timer_note >= 10)
            {
                findnoteReminder.SetActive(false);
                //timer_note = 0;
            }
        }
        else if (Notebook.grabnote == 1)
        {
            
            lecture = 1;
            if (!check_2)
            {
                MusicSource_cave.clip = NoteClip;
                MusicSource_cave.Play();
                OVRPlayerController.MoveScaleMultiplier = 0;
                check_2 = true;
            }
            if (flag == 0)
            {
                start_time = Time.realtimeSinceStartup;
                flag = 1;
            }
            if (Time.realtimeSinceStartup - start_time >= 1 && start_time != 0 && flag == 1)
            {
                note.SetActive(true);
                flag = 2;
            }
            if (Time.realtimeSinceStartup - start_time >= 26 && start_time != 0 && flag == 2)
            {
                note.SetActive(false);
                note2.SetActive(true);
                flag = 3;
            }
            if (Time.realtimeSinceStartup - start_time >= 49 && start_time != 0 && flag == 3)
            {
                note2.SetActive(false);
                OVRPlayerController.MoveScaleMultiplier = 0.6f;
                flag = 4;
                Notebook.grabnote = 0;
                lecture = 0;
            }
        }
        else if (stateManager2.CurrState == 3)
        {
            Done_3.SetActive(true);
        }
    }
}