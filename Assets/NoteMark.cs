using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMark : MonoBehaviour {

    GameObject player;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
    }
	
	// Update is called once per frame
	void Update () {
        if(player != GameObject.FindGameObjectWithTag("Player")) {
            player = GameObject.FindGameObjectWithTag("Player");
            Vector3 upMark = new Vector3(0, 1.3f, 0); 
            transform.position = player.transform.position + upMark;
            transform.localScale = player.transform.localScale;
        }
        if(player.GetComponent<StudentBehaviour>().fail || player.GetComponent<StudentBehaviour>().victory) {
            gameObject.SetActive(false);
        }
        else {
            gameObject.SetActive(true);
        }
    }
}
