using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TODOLIST2222 : MonoBehaviour {

    //public GameObject pausemenu;
    public GameObject map;
    public GameObject map2;
    public GameObject map3;
    public GameObject arrow;
    private double start_time = 0;
    private double timer = 0;
    private int flag = 0;
    static public int lectureVillage = 0;

    public GameObject Done_1;
    public GameObject Done_2;
    public GameObject Done_3;
    // Use this for initialization
    void Start()
    {
        //pausemenu.SetActive(false);

        //StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        /*if (pausemenu.activeInHierarchy == true && OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            pausemenu.SetActive(false);
            Debug.Log("Menu false");
        }
        else if (pausemenu.activeInHierarchy == false && OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            pausemenu.SetActive(true);
            Debug.Log("Menu true");
        }
        else if (pausemenu.activeInHierarchy == true && OVRInput.GetDown(OVRInput.RawButton.A))
        {
            //SceneManager.LoadScene("StartMenu");
        }
        else if (pausemenu.activeInHierarchy == true && OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            if (map.activeInHierarchy == true)
            {
                map.SetActive(false);
            }
            else
            {
                map.SetActive(true);
            }

        }*/

        if (ScrollUnfold.grab == 1)
        {
            Debug.Log(ScrollUnfold.grab);
            lectureVillage = 1;
            //Done_1.SetActive(true);
            //voideo
            if (flag == 0)
            {
                start_time = Time.realtimeSinceStartup;
                flag = 1;
            }
            if (Time.realtimeSinceStartup - start_time >= 5 && start_time != 0 && flag == 1)
            {
                map.SetActive(true);
                flag = 2;
            }
            if (Time.realtimeSinceStartup - start_time >= 10 && start_time != 0 && flag == 2)
            {
                map.SetActive(false);
                map2.SetActive(true);
                flag = 3;
            }
            if (Time.realtimeSinceStartup - start_time >= 15 && start_time != 0 && flag == 3)
            {
                map2.SetActive(false);
                map3.SetActive(true);
                flag = 4;
            }
            if (Time.realtimeSinceStartup - start_time >= 20 && start_time != 0 && flag == 4)
            {
                map3.SetActive(false);
                flag = 5;
                Done_1.SetActive(true);
                lectureVillage = 0;
                ScrollUnfold.grab = 0;
            }
        }
        else if (StateManager.CurrState == 2)
        {
            Done_2.SetActive(true);
            arrow.SetActive(true);
            /*timer += Time.deltaTime;
            if (timer >= 0.8)
            {
                if (arrow.activeInHierarchy)
                {
                    arrow.SetActive(false);
                } else
                {
                    arrow.SetActive(true);
                }
                timer = 0;
            }*/
        }
        else if (StateManager.CurrState == 3)
        {
            Done_3.SetActive(true);
        }
    }

}
