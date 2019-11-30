using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AirplaneController : MonoBehaviour {

    private bool isAlive;
    private bool isPaused;
    private float moveSpeed = 30f;
    // private float rotateSpeed = 3f;
    private GameObject spitfire;
    public Text scoreBoard;
    public GameObject gameOverPanel;
    public GameObject pausePanel;
    public GameObject tutorialPanel;
    public Text tutorialText;
    private int tutorial_2_counter = 0;
    private int tutorial_3_counter = 0;

    private AudioClip MusicClip_GameOver;
    private AudioClip MusicClip_Engine;
    private AudioClip MusicClip_Ambient;
    private AudioSource MusicSource;

    // Use this for initialization
    void Start () {
        isAlive = true;
        isPaused = false;
        gameOverPanel.SetActive(false);
        pausePanel.SetActive(false);
        tutorialPanel.SetActive(false);
        spitfire = GameObject.Find("Super_Spitfire");
        MusicSource = GetComponent<AudioSource>();

        MusicClip_GameOver = Resources.Load<AudioClip>("Sounds/GameOver");
        MusicClip_Engine = Resources.Load<AudioClip>("Sounds/Engine");
        MusicClip_Ambient = Resources.Load<AudioClip>("Sounds/Ambient");
        
        if (PlayMode.mode == "Tutorial")
        {
            tutorialPanel.SetActive(true);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (tutorialPanel.activeInHierarchy)
        {
            if (PlayMode.mode == "Tutorial")
            {
                tutorialText.text = "Welcome to the tutorial mode, the minions will guide through the control shcemes step by step. \n\nFollow the instructions and complete the tutorial \n\nPress B at anytime to quit the tutorial \nTake your time and enjoy a great flight! \n\nNow, Press A to move on";
                if (OVRInput.Get(OVRInput.RawButton.A))
                {
                    PlayMode.mode = "Tutorial_2";
                }
                else if (OVRInput.Get(OVRInput.RawButton.B))
                {
                    resetSpitfire();
                }
            }
            else if (PlayMode.mode == "Tutorial_2")
            {
                tutorialText.text = "Awesome! Now rotate your right touch controller and feel the plane. \n\nWarning: Please don't over-rotate or you might feel uncomfortable with it";
                if (tutorial_2_counter <= 500)
                {
                    if (transform.rotation != OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch))
                    {
                        tutorial_2_counter += 1;
                    }
                    transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
                }
                else
                {
                    tutorial_2_counter = 0;
                    PlayMode.mode = "Tutorial_3";
                }

                if (OVRInput.Get(OVRInput.RawButton.B))
                {
                    resetSpitfire();
                }
            }
            else if (PlayMode.mode == "Tutorial_3")
            {
                tutorialText.text = "Great! Now push/pull your right thumbstick and feel the acceleration/deceleration";
                if (tutorial_3_counter <= 500)
                {
                    float acceleration = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).x;
                    if (acceleration != 0)
                    {
                        tutorial_3_counter += 1;
                    }
                    spitfire.GetComponent<Rigidbody>().velocity = spitfire.transform.forward * moveSpeed;
                    if (moveSpeed + acceleration > 30f || moveSpeed + acceleration < 200f)
                    {
                        moveSpeed += acceleration;
                    }
                    else
                    {
                        moveSpeed = 30f;
                    }
                    transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
                }
                else
                {
                    tutorial_3_counter = 0;
                    PlayMode.mode = "Tutorial_4";
                }

                if (OVRInput.Get(OVRInput.RawButton.B))
                {
                    resetSpitfire();
                }
                
            }
            else if (PlayMode.mode == "Tutorial_4")
            {
                tutorialText.text = "Cool! Now you are ready for the game. \n\nPress X to shoot the spheres and reach a high score! \nYour score is shown on the left wing \n\nReminder: Press Y at anytime to pause the game \n\nPress A to end the tutorial and start the game";
                spitfire.transform.position = new Vector3(22f, 456, -904);
                spitfire.GetComponent<Rigidbody>().velocity = Vector3.zero;
                spitfire.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                spitfire.transform.rotation = Quaternion.identity;
                if (OVRInput.Get(OVRInput.RawButton.A) || OVRInput.Get(OVRInput.RawButton.B))
                {
                    resetSpitfire();
                }
            }
        }
        else
        {
            if (isAlive && !isPaused)
            {
                // Plane movement control
                float angle = 0.0f;
                Vector3 axis = Vector3.zero;
                OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).ToAngleAxis(out angle, out axis);
                Vector3 angles = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch).eulerAngles;

                spitfire.GetComponent<Rigidbody>().velocity = spitfire.transform.forward * moveSpeed;
                // transform.RotateAround(transform.position, axis, 0.004f * angle);
                // transform.rotation = Quaternion.Lerp(Quaternion.identity, OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch), 0.25f);
                transform.rotation = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
                // transform.Rotate(angles.x * 0.0005f, angles.y * 0.0005f, angles.z * 0.0005f);

                // Acceleration of Airplane
                float acceleration = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick).x;
                if (moveSpeed + acceleration > 30f || moveSpeed + acceleration < 200f)
                {
                    moveSpeed += acceleration;
                }
                else
                {
                    moveSpeed = 30f;
                }

                // Pause while in game
                if (OVRInput.Get(OVRInput.RawButton.Y))
                {
                    isPaused = true;
                    pausePanel.SetActive(true);
                    spitfire.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    spitfire.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
                }
            }

            if (pausePanel.activeInHierarchy)
            {
                if (OVRInput.Get(OVRInput.RawButton.B))
                {
                    MusicSource.clip = MusicClip_Engine;
                    MusicSource.Play(0);
                    isPaused = false;
                    pausePanel.SetActive(false);
                }
                else if (OVRInput.Get(OVRInput.RawButton.A))
                {
                    MusicSource.clip = MusicClip_Ambient;
                    MusicSource.Play(0);
                    SceneManager.LoadScene("StartMenu");
                }
            }
            else if (gameOverPanel.activeInHierarchy)
            {
                if (OVRInput.Get(OVRInput.RawButton.B))
                {
                    MusicSource.clip = MusicClip_Engine;
                    MusicSource.Play(0);
                    scoreBoard.text = "Score: 0";
                    gameOverPanel.SetActive(false);
                    isAlive = true;
                    moveSpeed = 30f;
                }
                else if (OVRInput.Get(OVRInput.RawButton.A))
                {
                    MusicSource.clip = MusicClip_Engine;
                    MusicSource.Play(0);
                    SceneManager.LoadScene("StartMenu");
                }
                else if (OVRInput.Get(OVRInput.RawButton.Y))
                {
#if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
#else
                        Application.Quit();
#endif
                }
            }
        }
    }

    private void resetSpitfire()
    {
        isAlive = true;
        moveSpeed = 30f;
        PlayMode.mode = "Normal";
        spitfire.transform.position = new Vector3(22f, 456, -904);
        spitfire.GetComponent<Rigidbody>().velocity = Vector3.zero;
        spitfire.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        spitfire.transform.rotation = Quaternion.identity;
        tutorialPanel.SetActive(false);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        // Debug.Log(collision.collider.tag);
        if (collision.collider.tag == "Target" || collision.collider.tag == "Terrain")
        {
            MusicSource.clip = MusicClip_GameOver;
            MusicSource.Play(0);
            isAlive = false;
            spitfire.transform.position = new Vector3(22f, 456, -904);
            spitfire.GetComponent<Rigidbody>().velocity = Vector3.zero;
            spitfire.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            spitfire.transform.rotation = Quaternion.identity;
            gameOverPanel.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "Target" || other.gameObject.tag == "Terrain")
        {
            isAlive = false;
            gameOverPanel.SetActive(true);
        }
    }
}
