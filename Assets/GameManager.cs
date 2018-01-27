using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour {

    bool keyLeft;
    bool keyRight;
    bool keyUp;
    bool keyDown;

    GameObject[] list;
    List<List<GameObject>> sortedDesks = new List<List<GameObject>>();
    List<GameObject> currentObjectList = new List<GameObject>();

    // Use this for initialization
    void Start () {
        list = GameObject.FindGameObjectsWithTag("Desk");
        initDesks();
    }
	
	// Update is called once per frame
	void Update () {
        keyLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        keyRight = Input.GetKeyDown(KeyCode.RightArrow);
        keyUp = Input.GetKeyDown(KeyCode.UpArrow);
        keyDown = Input.GetKeyDown(KeyCode.DownArrow);

        if (keyDown) moveDown();
        if (keyUp) moveUp();
        if (keyLeft) moveLeft();
        if (keyRight) moveRight();
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
        foreach(GameObject lObject in list)
        {
            if (lObject.GetComponent<StudentBehaviour>().player)
            {
                lObject.GetComponent<StudentBehaviour>().goDown();
                return;
            }
        }
    }

    void moveUp()
    {
        foreach (GameObject lObject in list)
        {
            if (lObject.GetComponent<StudentBehaviour>().player)
            {
                lObject.GetComponent<StudentBehaviour>().goUp();
                return;
            }
        }
    }

    void moveLeft()
    {
        foreach (GameObject lObject in list)
        {
            if (lObject.GetComponent<StudentBehaviour>().player)
            {
                lObject.GetComponent<StudentBehaviour>().goLeft();
                return;
            }
        }
    }

    void moveRight()
    {
        foreach (GameObject lObject in list)
        {
            if (lObject.GetComponent<StudentBehaviour>().player)
            {
                lObject.GetComponent<StudentBehaviour>().goRight();
                return;
            }
        }
    }

}
