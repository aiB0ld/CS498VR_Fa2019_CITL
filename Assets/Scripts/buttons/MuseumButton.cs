using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MuseumButton : MonoBehaviour
{
    //public GameObject target_1;
    public GameObject learnobj;
    public GameObject realPause;
    public GameObject todolist;
    //public Color onTouchColor;
    private Image btnImage;
    public Sprite originalSprite;
    public Sprite onTouchSprite;
    private Button learnobjBtn;
    public float grabBegin = 0.05f;
    public float grabEnd = 0.05f;
    private float l_flex;
    private float r_flex;
    //public GameObject todoreminder;

    // Use this for initialization
    void Start()
    {
        btnImage = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    private bool CheckForGrabOrRelease(float flex, float prevFlex)
    {
        if ((flex >= grabBegin) && (prevFlex < grabBegin))
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
            btnImage.sprite = onTouchSprite;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        float l_prevFlex = l_flex;
        l_flex = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.LTouch);
        float r_prevFlex = r_flex;
        r_flex = OVRInput.Get(OVRInput.Axis1D.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        if (other.gameObject.CompareTag("Hand"))
        {
            if (CheckForGrabOrRelease(l_flex, l_prevFlex) || CheckForGrabOrRelease(r_flex, r_prevFlex))
            {
                btnImage.sprite = originalSprite;

                if (gameObject.name == "learningobjectives")
                {
                    if (learnobj.activeInHierarchy)
                    {
                        learnobj.SetActive(false);
                    }
                    else
                    {
                        //todoreminder.SetActive(false);
                        todolist.SetActive(false);
                        learnobj.SetActive(true);
                        realPause.SetActive(false);
                    }
                }   
                else if (gameObject.name == "starmenu")
                {
                    SceneManager.LoadScene("StartMenu");
                    OVRPlayerController.MoveScaleMultiplier = 0;
                }
                else if (gameObject.name == "todolist")
                {
                    if (todolist.activeInHierarchy)
                    {
                        todolist.SetActive(false);
                    }
                    else
                    {
                        //todoreminder.SetActive(false);
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
            btnImage.sprite = originalSprite;
        }
    }
}
