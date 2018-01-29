using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StudentBehaviour : MonoBehaviour {

    public bool goodGuy;
    public bool badGuy;
    public bool nerd;
    public bool jealous;

    public bool crush;
    public bool player;

    public bool start;

    public GameObject deskOnTheLeft;
    public GameObject deskOnTheRight;
    public GameObject deskOnTheTop;
    public GameObject deskOnTheBottom;

    bool moved = false;
    public bool fail = false;
    public bool victory = false;

    float lastPressedTime = 0;

    Animator animator;

    GameObject[] list;
    List<List<GameObject>> sortedDesks = new List<List<GameObject>>();
    List<GameObject> currentList = new List<GameObject>();

    public FMOD.Studio.EventInstance soundBad;
    public FMOD.Studio.EventInstance soundNerd;
    public FMOD.Studio.EventInstance soundJealous;
    public FMOD.Studio.EventInstance soundGood;
    public FMOD.Studio.EventInstance soundPaperPass;

    // Use this for initialization
    void Start () {
        list = GameObject.FindGameObjectsWithTag("Desk");
        animator = GetComponent<Animator>();

        soundBad = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Student/sfx_Bad");
        soundNerd = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Student/sfx_Nerd");
        soundJealous = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Student/sfx_Jealous");
        soundGood = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Student/sfx_Good");
        soundPaperPass = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/PassPeper");
    }

    // Update is called once per framea
    void Update () {

        if (gameObject.tag == "Player" && crush) victory = true;
        if (gameObject.tag == "Player" && nerd) fail = true;

        //random action on iddle guys
        if (gameObject.tag != "Player" && nerd || badGuy || jealous) {
            if(Random.Range(-10.0f, 1000.0f) < -9.4) {
                animator.SetTrigger("randomAction");
            }
        }

        if (gameObject.tag == "Player" && jealous) Invoke("doActionJealous", 1);
        if (gameObject.tag == "Player") animator.SetBool("isPlayer", true);
        else animator.SetBool("isPlayer", false);
    }

    public void goDown()
    {
        if (deskOnTheBottom != null && !fail)
        {
            gameObject.tag = "Desk";
            deskOnTheBottom.gameObject.tag = "Player";
            GameObject.Find("Teacher").GetComponent<Teacher>().soundLevel++;
            if (deskOnTheBottom.GetComponent<StudentBehaviour>().nerd) soundNerd.start();
            if (deskOnTheBottom.GetComponent<StudentBehaviour>().badGuy) soundBad.start();
            if (deskOnTheBottom.GetComponent<StudentBehaviour>().goodGuy) soundGood.start();
            if (deskOnTheBottom.GetComponent<StudentBehaviour>().jealous) soundJealous.start();
            soundPaperPass.start();
        }
    }

    public void goLeft()
    {
        if (deskOnTheLeft != null && !fail)
        {
            gameObject.tag = "Desk";
            deskOnTheLeft.gameObject.tag = "Player";
            GameObject.Find("Teacher").GetComponent<Teacher>().soundLevel++;
            if (deskOnTheLeft.GetComponent<StudentBehaviour>().nerd) soundNerd.start();
            if (deskOnTheLeft.GetComponent<StudentBehaviour>().badGuy) soundBad.start();
            if (deskOnTheLeft.GetComponent<StudentBehaviour>().goodGuy) soundGood.start();
            if (deskOnTheLeft.GetComponent<StudentBehaviour>().jealous) soundJealous.start();
            soundPaperPass.start();
        }
    }

    public void goRight()
    {
        if (deskOnTheRight != null && !fail)
        {
            gameObject.tag = "Desk";
            deskOnTheRight.gameObject.tag = "Player";
            GameObject.Find("Teacher").GetComponent<Teacher>().soundLevel++;
            if (deskOnTheRight.GetComponent<StudentBehaviour>().nerd) soundNerd.start();
            if (deskOnTheRight.GetComponent<StudentBehaviour>().badGuy) soundBad.start();
            if (deskOnTheRight.GetComponent<StudentBehaviour>().goodGuy) soundGood.start();
            if (deskOnTheRight.GetComponent<StudentBehaviour>().jealous) soundJealous.start();
            soundPaperPass.start();
        }
    }

    public void goUp()
    {
        if (deskOnTheTop != null && !fail)
        {
            gameObject.tag = "Desk";
            deskOnTheTop.gameObject.tag = "Player";
            GameObject.Find("Teacher").GetComponent<Teacher>().soundLevel++;
            if (deskOnTheTop.GetComponent<StudentBehaviour>().nerd) soundNerd.start();
            if (deskOnTheTop.GetComponent<StudentBehaviour>().badGuy) soundBad.start();
            if (deskOnTheTop.GetComponent<StudentBehaviour>().goodGuy) soundGood.start();
            if (deskOnTheTop.GetComponent<StudentBehaviour>().jealous) soundJealous.start();
            soundPaperPass.start();
        }
    }

    void doActionJealous() {
        GameObject[] lList = GameObject.FindGameObjectsWithTag("Desk");
        foreach (GameObject lObject in lList) {
            if (lObject.gameObject.GetComponent<StudentBehaviour>().start) {
                gameObject.tag = "Desk";
                lObject.gameObject.tag = "Player";
            }
        }
    }
}
