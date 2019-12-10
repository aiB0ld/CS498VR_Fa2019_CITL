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
    public GameObject urnCanves;

    public AudioClip UrnClip;
    public AudioClip NoteClip;
    public AudioSource MusicSource_cave;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (StateManager.CurrState == 1)
        {
            Done_1.SetActive(true);
            urnCanves.SetActive(true);
            if (!check_1)
            {
                MusicSource_cave.Play();
                check_1 = true;
            }
        }
        else if (Notebook.grabnote == 1)
        {
            urnCanves.SetActive(false);
            lecture = 1;
            if (!check_2)
            {
                MusicSource_cave.clip = NoteClip;
                MusicSource_cave.Play();
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
                flag = 4;
                Notebook.grabnote = 0;
                lecture = 0;
            }
        }
        else if (StateManager.CurrState == 3)
        {
            Done_3.SetActive(true);
        }
    }
}