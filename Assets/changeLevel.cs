using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changeLevel : MonoBehaviour
{

    bool keyLeft;
    bool keyRight;
    bool keyUp;
    bool keyDown;

    public List<string> listLevel;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        keyLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        keyRight = Input.GetKeyDown(KeyCode.RightArrow);
        keyUp = Input.GetKeyDown(KeyCode.UpArrow);
        keyDown = Input.GetKeyDown(KeyCode.DownArrow);

        if (keyDown || keyLeft || keyRight || keyUp || Input.GetMouseButtonDown(0) || Input.GetKeyDown("space"))
            ChangeLevel();
    }

    void ChangeLevel()
    {
        int selection = int.Parse(Mathf.Floor(Random.value * 3).ToString());

        if (listLevel[selection] != SceneManager.GetActiveScene().ToString())
        {
            SceneManager.LoadScene(listLevel[selection], LoadSceneMode.Single);
            listLevel.Remove(listLevel[selection]);
        }
        else ChangeLevel();
    }
}