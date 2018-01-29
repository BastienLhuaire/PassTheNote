using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject menu; // Assign in inspector

    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<StudentBehaviour>().fail)
        {
            menu.SetActive(true);
        }
    }
}