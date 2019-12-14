using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScriptStart : MonoBehaviour
{
    //public GameObject target_1;
    public GameObject stageMenu;
    public GameObject buttonCanvas;

    //public Color onTouchColor;
    private Image btnImage;
    public Sprite originalSprite;
    public Sprite onTouchSprite;
    private Button learnobjBtn;
    public float grabBegin = 0.05f;
    public float grabEnd = 0.05f;
    private float l_flex;
    private float r_flex;

    static public float xuehao;

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

                if (StartMenuPlayerController.mode == "tutorial")
                {
                    StartMenuPlayerController.isTriggered = true;
                    if (buttonCanvas.activeInHierarchy)
                    {
                        buttonCanvas.SetActive(false);
                    }
                } else
                {
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
                        xuehao = Time.realtimeSinceStartup;
                        SceneManager.LoadScene("VillageScene");
                        OVRPlayerController.MoveScaleMultiplier = 0.6f;
                    } else if (gameObject.name == "Tutorial")
                    {
                        StartMenuPlayerController.mode = "tutorial";
                        StartMenuPlayerController.stage = "menu";
                        StartMenuPlayerController.isTriggered = false;
                        StartMenuPlayerController.isGrabbed = false;
                    }
                    else if (gameObject.name == "Stage")
                    {
                        if (stageMenu.activeInHierarchy)
                        {
                            stageMenu.SetActive(false);
                        }else
                        {
                            stageMenu.SetActive(true);
                        }   
                    }
                    else if (gameObject.name == "village")
                    {
                        xuehao = Time.realtimeSinceStartup;
                        SceneManager.LoadScene("VillageScene");
                        OVRPlayerController.MoveScaleMultiplier = 0.6f;
                    }
                    else if (gameObject.name == "village2")
                    {
                        SceneManager.LoadScene("Village2ndScene");
                        OVRPlayerController.MoveScaleMultiplier = 1.0f;
                    }
                    else if (gameObject.name == "cave")
                    {
                        SceneManager.LoadScene("CaveScene");
                        OVRPlayerController.MoveScaleMultiplier = 0.6f;
                        StateManager.cave_timer = Time.realtimeSinceStartup;
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
