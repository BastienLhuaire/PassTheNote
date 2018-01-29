using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour {

    public GameObject menu; // Assign in inspector

    void Update() {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<StudentBehaviour>().victory) {
            menu.SetActive(true);
        }
    }
}
