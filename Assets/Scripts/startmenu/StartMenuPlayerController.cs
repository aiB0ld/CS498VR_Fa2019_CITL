using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuPlayerController : MonoBehaviour {

    static public string mode;
    static public string stage;
    static public bool isTriggered;
    static public bool isGrabbed;

    public GameObject menuButtonReminder;
    public GameObject triggerButtonReminder;
    public GameObject moveButtonReminder;
    public GameObject grabButtonReminder;
    public GameObject island;

    public GameObject buttonCanvas;
    public GameObject startText;
    public GameObject stageText;
    public GameObject exitText;
    public GameObject tutorialText;
    public GameObject welcomeAreminder;

    public GameObject startMenuRock;
    static public bool check_mode = false;

    // Use this for initialization
    void Start ()
    {
        OVRPlayerController.MoveScaleMultiplier = 0;
        stage = "none";
        isTriggered = false;
        isGrabbed = false;

    }

    // Update is called once per frame
    void Update () {
        if (! check_mode)
        {
            mode = "before_tutorial";
            check_mode = true;
            welcomeAreminder.SetActive(true);
        }

        if (mode != "before_tutorial" && OVRInput.GetDown(OVRInput.RawButton.Start))
        {
            if (buttonCanvas.activeInHierarchy)
            {
                buttonCanvas.SetActive(false);
            }
            else
            {
                buttonCanvas.SetActive(true);
            }

        }

        if (mode == "tutorial")
        {
            exitText.GetComponent<Text>().text = "Click Me!";
            exitText.GetComponent<Text>().fontSize = 18;
            tutorialText.GetComponent<Text>().text = "Click Me!";
            tutorialText.GetComponent<Text>().fontSize = 18;
            startText.GetComponent<Text>().text = "Click Me!";
            startText.GetComponent<Text>().fontSize = 18;
            stageText.GetComponent<Text>().text = "Click Me!";
            stageText.GetComponent<Text>().fontSize = 18;
        }
        else
        {
            exitText.GetComponent<Text>().text = "EXIT";
            exitText.GetComponent<Text>().fontSize = 25;
            tutorialText.GetComponent<Text>().text = "TUTORIAL";
            tutorialText.GetComponent<Text>().fontSize = 18;
            startText.GetComponent<Text>().text = "START";
            startText.GetComponent<Text>().fontSize = 25;
            stageText.GetComponent<Text>().text = "STAGE";
            stageText.GetComponent<Text>().fontSize = 25;
        }

        if (mode == "before_tutorial")
        {
            OVRPlayerController.MoveScaleMultiplier = 0f;
            if (OVRInput.Get(OVRInput.RawButton.A))
            {
                mode = "tutorial";
                stage = "menu";
                
            }
        } else if (mode == "tutorial")
        {
            if (stage == "menu")
            {
                island.SetActive(false);
                welcomeAreminder.SetActive(false);
                menuButtonReminder.SetActive(true);
                if (OVRInput.Get(OVRInput.RawButton.Start))
                {
                    stage = "trigger";
                    menuButtonReminder.SetActive(false);
                }
            } else if (stage == "trigger")
            {
                triggerButtonReminder.SetActive(true);
                if (isTriggered)
                {
                    stage = "move";
                    triggerButtonReminder.SetActive(false);
                    OVRPlayerController.MoveScaleMultiplier = 0.6f;
                }
            }
            else if (stage == "move")
            {
                moveButtonReminder.SetActive(true);
                if (OVRInput.Get(OVRInput.RawAxis2D.LThumbstick) != Vector2.zero || OVRInput.Get(OVRInput.RawAxis2D.RThumbstick) != Vector2.zero)
                {
                    stage = "grab";
                    moveButtonReminder.SetActive(false);
                    startMenuRock.SetActive(true);
                }
            }
            else if (stage == "grab")
            {
                grabButtonReminder.SetActive(true);
                if (isGrabbed)
                {
                    mode = "after_tutorial";
                    stage = "none";
                    isTriggered = false;
                    isGrabbed = false;
                    grabButtonReminder.SetActive(false);
                    startMenuRock.SetActive(false);
                    startMenuRock.transform.position = new Vector3(-12.7f, 1.1f, -4.5f);
                    gameObject.transform.position = new Vector3(-11f, 0.95f, -4.6f);
                    island.SetActive(true);
                    OVRPlayerController.MoveScaleMultiplier = 0f;
                }
            }
        } else
        {
            //OVRPlayerController.MoveScaleMultiplier = 0f;
        }
    }
}
