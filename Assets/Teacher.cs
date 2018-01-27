using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour {

    //Look Behind
    private bool isLooking      = false;
    private bool noteMoving     = false;
    public int   timeLookBehind = 5;

    //Sound Level
    public int   soundLevel         = 0;
    public float increaseSecondRate = 10;
    public int   soundLevelMax      = 10;
 

    // Use this for initialization
    void Start() {
        InvokeRepeating("IncreaseSound", increaseSecondRate, increaseSecondRate);
    }

    // Update is called once per frame
    void Update() {
        if (soundLevel >= soundLevelMax && !isLooking) { 
            isLooking = true;
            Invoke("StopLookingBehind", 5);
        }
        if (isLooking) LookBehind();
    }

    //Increase the Sound Level by increaseNumber
    void IncreaseSound() {
        soundLevel += 1;
    }

    //Function call when the Teacher stop looking behind
    void StopLookingBehind() {
        isLooking = false;
        soundLevel = 0;
        this.GetComponent<SpriteRenderer>().color = Color.white;
        print("StopLooking");
    }

    //Function call when the Teacher look behind
    void LookBehind() {
        print("isLooking");
        this.GetComponent<SpriteRenderer>().color = Color.red;
        if (noteMoving) {
            print("Game Over");
        }
    }
}