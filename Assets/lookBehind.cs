using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookBehind : MonoBehaviour {

    public bool isLooking = false;
    public int soundLevel = 0;
    float increaseSecondRate = 0.1f;

    // Use this for initialization
    void Start () {
        InvokeRepeating("IncreaseSound", 1.0f, increaseSecondRate);
	}
	
	// Update is called once per frame
	void Update () {
        IncreaseSound();
    }

    void IncreaseSound() {
        soundLevel += 1;
        print(soundLevel);
    }
}