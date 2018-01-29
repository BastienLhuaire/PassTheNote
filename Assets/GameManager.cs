using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour {

    bool keyLeft;
    bool keyRight;
    bool keyUp;
    bool keyDown;

    GameObject player;

    float moveSpeed = 0.5f;

    GameObject[] list;
    List<List<GameObject>> sortedDesks = new List<List<GameObject>>();
    List<GameObject> currentObjectList = new List<GameObject>();


    // Use this for initialization
    void Start () {
        list = GameObject.FindGameObjectsWithTag("Desk");
        initDesks();

        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        keyLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        keyRight = Input.GetKeyDown(KeyCode.RightArrow);
        keyUp = Input.GetKeyDown(KeyCode.UpArrow);
        keyDown = Input.GetKeyDown(KeyCode.DownArrow);

        if (keyDown && player.GetComponent<StudentBehaviour>().deskOnTheBottom != null && !player.GetComponent<StudentBehaviour>().fail) {
            if (player.GetComponent<StudentBehaviour>().badGuy)
                player.GetComponent<Animator>().SetTrigger("passBack");
            else
                player.GetComponent<Animator>().SetTrigger("passFront");
            GameObject.Find("Teacher").GetComponent<Teacher>().noteMoving = true;
            Invoke("moveDown", moveSpeed);
        }
        else if (keyUp && player.GetComponent<StudentBehaviour>().deskOnTheTop != null && !player.GetComponent<StudentBehaviour>().fail) {
            if (player.GetComponent<StudentBehaviour>().badGuy)
                player.GetComponent<Animator>().SetTrigger("passFront");
            else
                player.GetComponent<Animator>().SetTrigger("passBack");
            GameObject.Find("Teacher").GetComponent<Teacher>().noteMoving = true;
            Invoke("moveUp", moveSpeed);
        }
        else if (keyLeft && player.GetComponent<StudentBehaviour>().deskOnTheLeft != null && !player.GetComponent<StudentBehaviour>().fail) {
            if (player.GetComponent<StudentBehaviour>().badGuy)
                player.GetComponent<Animator>().SetTrigger("passRight");
            else
                player.GetComponent<Animator>().SetTrigger("passLeft");
            GameObject.Find("Teacher").GetComponent<Teacher>().noteMoving = true;
            Invoke("moveLeft", moveSpeed);
        }
        else if (keyRight && player.GetComponent<StudentBehaviour>().deskOnTheRight != null && !player.GetComponent<StudentBehaviour>().fail) {
            if (player.GetComponent<StudentBehaviour>().badGuy)
                player.GetComponent<Animator>().SetTrigger("passLeft");
            else
                player.GetComponent<Animator>().SetTrigger("passRight");
            GameObject.Find("Teacher").GetComponent<Teacher>().noteMoving = true;
            Invoke("moveRight", moveSpeed);
        };
    }

    void initDesks()
    {
        for (int i = 0; i < 5; i++) sortedDesks.Add(new List<GameObject>());

        foreach (GameObject lObject in list)
        {
            if (lObject.transform.position.x == -4) sortedDesks[0].Add(lObject);
            else if (lObject.transform.position.x == -2) sortedDesks[1].Add(lObject);
            else if (lObject.transform.position.x == 0) sortedDesks[2].Add(lObject);
            else if (lObject.transform.position.x == 2) sortedDesks[3].Add(lObject);
            else if (lObject.transform.position.x == 4) sortedDesks[4].Add(lObject);
        }

        for (int i = 0; i < sortedDesks.Count; i++)
        {
            sortedDesks[i] = sortedDesks[i].OrderBy(t => t.transform.position.y).ToList();
        }
    }

    void moveDown()
    {
        if (player.GetComponent<StudentBehaviour>().badGuy) player.GetComponent<StudentBehaviour>().goUp();
        else if (player.GetComponent<StudentBehaviour>().goodGuy) player.GetComponent<StudentBehaviour>().goDown();
        GameObject.Find("Teacher").GetComponent<Teacher>().noteMoving = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void moveUp()
    {
        if (player.GetComponent<StudentBehaviour>().badGuy) player.GetComponent<StudentBehaviour>().goDown();
        else if (player.GetComponent<StudentBehaviour>().goodGuy) player.GetComponent<StudentBehaviour>().goUp();
        GameObject.Find("Teacher").GetComponent<Teacher>().noteMoving = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void moveLeft()
    {
        if (player.GetComponent<StudentBehaviour>().badGuy) player.GetComponent<StudentBehaviour>().goRight();
        else if (player.GetComponent<StudentBehaviour>().goodGuy) player.GetComponent<StudentBehaviour>().goLeft();
        GameObject.Find("Teacher").GetComponent<Teacher>().noteMoving = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void moveRight()
    { 
        if (player.GetComponent<StudentBehaviour>().badGuy) player.GetComponent<StudentBehaviour>().goLeft();
        else if (player.GetComponent<StudentBehaviour>().goodGuy) player.GetComponent<StudentBehaviour>().goRight();
        GameObject.Find("Teacher").GetComponent<Teacher>().noteMoving = false;
        player = GameObject.FindGameObjectWithTag("Player");
    }

}
