using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentBehaviour : MonoBehaviour {

    public bool goodGuy;
    public bool badGuy;
    public bool nerd;
    public bool player;

    public bool left;
    public bool right;
    public bool up;
    public bool down;
    public bool center;
    public bool perfectCenter;

    bool keyLeft;
    bool keyRight;
    bool keyUp;
    bool keyDown;

    GameObject[] list;

    // Use this for initialization
    void Start () {
        list = GameObject.FindGameObjectsWithTag("Desk");
        print(transform.position);
    }
	
	// Update is called once per frame
	void Update () {

        keyLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        keyRight = Input.GetKeyDown(KeyCode.RightArrow);
        keyUp = Input.GetKeyDown(KeyCode.UpArrow);
        keyDown = Input.GetKeyDown(KeyCode.DownArrow);

        if (keyDown && player) goDown();
        if (keyRight && player) goRight();
        if (keyUp && player) goUp();
        if (keyLeft && player) goLeft();

        if (player == true) this.GetComponent<SpriteRenderer>().color = Color.red;
    }

    void goDown()
    {
        foreach (GameObject lObject in list)
        {
            if (lObject != this.gameObject && lObject.transform.position.x == transform.position.x && lObject.transform.position.y < transform.position.y)
            {
                lObject.gameObject.GetComponent<StudentBehaviour>().player = true;
                NoteMove();
            }
        }
    }

    void goLeft()
    {
        foreach (GameObject lObject in list)
        {
            if (lObject != this.gameObject && lObject.transform.position.x < transform.position.x && lObject.transform.position.y == transform.position.y)
            {
                lObject.gameObject.GetComponent<StudentBehaviour>().player = true;
                NoteMove();
            }
        }
    }

    void goRight()
    {
        foreach (GameObject lObject in list)
        {
            if (lObject != this.gameObject && lObject.transform.position.x > transform.position.x && lObject.transform.position.y == transform.position.y)
            {
                lObject.gameObject.GetComponent<StudentBehaviour>().player = true;
                NoteMove();
            }
        }
    }

    void goUp()
    {
        foreach (GameObject lObject in list)
        {
            if (lObject != this.gameObject && lObject.transform.position.x == transform.position.x && lObject.transform.position.y > transform.position.y)
            {
                lObject.gameObject.GetComponent<StudentBehaviour>().player = true;
                NoteMove();
            }
        }
    }

    void NoteMove() {
        this.player = false;
        print(player);
        this.GetComponent<SpriteRenderer>().color = Color.white;
        GameObject.Find("Teacher").GetComponent<Teacher>().soundLevel += 1;
    }

    void doActionGoodguy()
    {

    }

    void doActionBadGuy()
    {

    }

    void doActionNerd()
    {
        if (this.player) {

        }
    }
}
