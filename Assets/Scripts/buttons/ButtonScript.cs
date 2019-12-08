using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    //public GameObject target_1;
    public GameObject learnobj;
    public GameObject realPause;
    public GameObject todolist;
    public GameObject mapmap;
    public Color onTouchColor;
    private Button learnobjBtn;
    public float grabBegin = 0.05f;
    public float grabEnd = 0.05f;
    private float m_prevFlex;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {


    }

    private bool CheckForGrabOrRelease(float prevFlex)
    {
        if ((m_prevFlex >= grabBegin) && (prevFlex < grabBegin))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            learnobjBtn = gameObject.GetComponent<Button>();
            var colors = learnobjBtn.colors;
            colors.normalColor = onTouchColor;
            learnobjBtn.colors = colors;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        float prevFlex = m_prevFlex;
        m_prevFlex = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        if (other.gameObject.CompareTag("Hand"))
        {
            if (CheckForGrabOrRelease(prevFlex))
            {
                learnobjBtn = gameObject.GetComponent<Button>();
                var colors = learnobjBtn.colors;
                colors.normalColor = Color.white;
                learnobjBtn.colors = colors;

                if (gameObject.name == "learningobjectives")
                {
                    if (learnobj.activeInHierarchy)
                    {
                        learnobj.SetActive(false);
                    }
                    else
                    {
                        mapmap.SetActive(false);
                        todolist.SetActive(false);
                        learnobj.SetActive(true);
                        realPause.SetActive(false);
                    }
                }
                else if (gameObject.name == "map")
                {
                    if (mapmap.activeInHierarchy)
                    {
                        mapmap.SetActive(false);
                    }
                    else
                    {
                        todolist.SetActive(false);
                        learnobj.SetActive(false);
                        mapmap.SetActive(true);
                        realPause.SetActive(false);
                    }
                }
                else if (gameObject.name == "starmenu")
                {
                    SceneManager.LoadScene("StartMenu");
                }
                else if (gameObject.name == "todolist")
                {
                    if (todolist.activeInHierarchy)
                    {
                        todolist.SetActive(false);
                    }
                    else
                    {
                        mapmap.SetActive(false);
                        learnobj.SetActive(false);
                        todolist.SetActive(true);
                        realPause.SetActive(false);
                    }
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Hand"))
        {
            learnobjBtn = gameObject.GetComponent<Button>();
            var colors = learnobjBtn.colors;
            colors.normalColor = Color.white;
            learnobjBtn.colors = colors;
        }
    }
}
