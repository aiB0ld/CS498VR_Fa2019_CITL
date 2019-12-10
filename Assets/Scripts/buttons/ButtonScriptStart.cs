using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScriptStart : MonoBehaviour
{
    //public GameObject target_1;
    public GameObject stageMenu;

    public Color onTouchColor;
    private Button learnobjBtn;
    public float grabBegin = 0.05f;
    public float grabEnd = 0.05f;
    private float l_flex;
    private float r_flex;

    // Use this for initialization
    void Start()
    {
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
            learnobjBtn = gameObject.GetComponent<Button>();
            var colors = learnobjBtn.colors;
            colors.normalColor = onTouchColor;
            learnobjBtn.colors = colors;
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
                learnobjBtn = gameObject.GetComponent<Button>();
                var colors = learnobjBtn.colors;
                colors.normalColor = Color.white;
                learnobjBtn.colors = colors;

                if (gameObject.name == "Exit")
                {
                    #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
                    #else
                        Application.Quit();
                    #endif
                }
                else if (gameObject.name == "Start")
                {
                    SceneManager.LoadScene("VillageScene");
                }
                else if (gameObject.name == "Stage")
                {
                    stageMenu.SetActive(true);
                }
                else if (gameObject.name == "village")
                {
                    SceneManager.LoadScene("VillageScene");
                }
                else if (gameObject.name == "village2")
                {
                    //SceneManager.LoadScene("VillageScene");
                }
                else if (gameObject.name == "cave")
                {
                    SceneManager.LoadScene("CaveScene");
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
