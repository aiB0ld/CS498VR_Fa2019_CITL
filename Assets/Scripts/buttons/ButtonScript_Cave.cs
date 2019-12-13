using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript_Cave : MonoBehaviour
{
    //public GameObject target_1;
    public GameObject learnobj;
    public GameObject realPause;
    public GameObject todolist;
    public GameObject notebook;
    //public Color onTouchColor;
    private Button learnobjBtn;
    private Image btnImage;
    public Sprite originalSprite;
    public Sprite onTouchSprite;
    public float grabBegin = 0.05f;
    public float grabEnd = 0.05f;
    private float l_flex;
    private float r_flex;
    public GameObject todoreminderrr;

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
            //learnobjBtn = gameObject.GetComponent<Button>();
            //var colors = learnobjBtn.colors;
            //colors.normalColor = onTouchColor;
            //learnobjBtn.colors = colors;
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
                //learnobjBtn = gameObject.GetComponent<Button>();
                //var colors = learnobjBtn.colors;
                //colors.normalColor = Color.white;
                //learnobjBtn.colors = colors;

                if (gameObject.name == "learningobjectives")
                {
                    if (learnobj.activeInHierarchy)
                    {
                        learnobj.SetActive(false);
                    }
                    else
                    {
                        todoreminderrr.SetActive(false);
                        notebook.SetActive(false);
                        todolist.SetActive(false);
                        learnobj.SetActive(true);
                        realPause.SetActive(false);
                    }
                }
                else if (gameObject.name == "notebook")
                {
                    if (notebook.activeInHierarchy)
                    {
                        notebook.SetActive(false);
                    }
                    else
                    {
                        todoreminderrr.SetActive(false);
                        todolist.SetActive(false);
                        learnobj.SetActive(false);
                        notebook.SetActive(true);
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
                        todoreminderrr.SetActive(false);
                        notebook.SetActive(false);
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
            //learnobjBtn = gameObject.GetComponent<Button>();
            //var colors = learnobjBtn.colors;
            //colors.normalColor = Color.white;
            //learnobjBtn.colors = colors;
        }
    }
}
