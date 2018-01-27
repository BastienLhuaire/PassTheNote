using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StudentBehaviour : MonoBehaviour {

    public bool goodGuy;
    public bool badGuy;
    public bool nerd;
    public bool player;

    bool keyLeft;
    bool keyRight;
    bool keyUp;
    bool keyDown;

    bool moved = false;

    float lastPressedTime = 0;

    GameObject[] list;
    List<List<GameObject>> sortedDesks = new List<List<GameObject>>();
    List<GameObject> currentList = new List<GameObject>();

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


        //if (Input.GetKeyUp(KeyCode.DownArrow)) keyPressed = false; ;

        //if (keyDown && player) goDown();
        //if (keyRight && player) goRight();
        //if (keyUp && player) goUp();
        //if (keyLeft && player) goLeft();

        if (player) this.GetComponent<SpriteRenderer>().color = Color.red;
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
            if (sortedDesks[i].Contains(this.gameObject)) currentList = sortedDesks[i];
        }
        
    }

    public void goDown()
    {
        if (currentList[currentList.IndexOf(this.gameObject) - 1] != null)
        {
            currentList[currentList.IndexOf(this.gameObject) - 1].gameObject.GetComponent<StudentBehaviour>().player = true;
            this.player = false;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            GameObject.Find("Teacher").GetComponent<Teacher>().soundLevel += 1;
        }
    }

    public void goLeft()
    {
        if (sortedDesks[sortedDesks.IndexOf(currentList) - 1] != null)
        {
            sortedDesks[sortedDesks.IndexOf(currentList) - 1][currentList.IndexOf(this.gameObject)].gameObject.GetComponent<StudentBehaviour>().player = true;
            this.player = false;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            GameObject.Find("Teacher").GetComponent<Teacher>().soundLevel += 1;
        }
    }

    public void goRight()
    {
        if (sortedDesks[sortedDesks.IndexOf(currentList) + 1] != null)
        {
            sortedDesks[sortedDesks.IndexOf(currentList) + 1][currentList.IndexOf(this.gameObject)].gameObject.GetComponent<StudentBehaviour>().player = true;
            this.player = false;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            GameObject.Find("Teacher").GetComponent<Teacher>().soundLevel += 1;
        }
    }

    public void goUp()
    {
        if (currentList[currentList.IndexOf(this.gameObject) + 1] != null)
        {
            currentList[currentList.IndexOf(this.gameObject) + 1].gameObject.GetComponent<StudentBehaviour>().player = true;
            this.player = false;
            this.GetComponent<SpriteRenderer>().color = Color.white;
            GameObject.Find("Teacher").GetComponent<Teacher>().soundLevel += 1;
        }
    }

    void doActionGoodguy()
    {

    }

    void doActionBadGuy()
    {

    }

    void doActionNerd()
    {

    }
}
