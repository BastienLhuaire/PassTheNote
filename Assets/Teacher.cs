using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : MonoBehaviour {
    //Animator
    Animator anim;
    //Look Behind
    private bool isLooking      = false;
    public bool noteMoving     = false;
    public int   timeLookBehind = 5;

    //Sound Level
    public int   soundLevel         = 0;
    public float increaseSecondRate = 10;
    public int   soundLevelMax      = 10;
 

    // Use this for initialization
    void Start() {
        InvokeRepeating("IncreaseSound", increaseSecondRate, increaseSecondRate);
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        if (soundLevel >= soundLevelMax && !isLooking) { 
            isLooking = true;
            Invoke("StopLookingBehind", 5);
        }
        if (isLooking) LookBehind();
        anim.SetFloat("angerLevel", soundLevel);

        FMODUnity.StudioParameterTrigger obj = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<FMODUnity.StudioParameterTrigger>();
        obj.Emitters[0].Target.SetParameter("AngerLevel", soundLevel);
    }

    //Increase the Sound Level by increaseNumber
    void IncreaseSound() {
        soundLevel += 1;
    }

    //Function call when the Teacher stop looking behind
    void StopLookingBehind() {
        isLooking = false;
        soundLevel = 0;
        anim.SetBool("isLooking", false);
    }

    //Function call when the Teacher look behind
    void LookBehind() {
        print("isLooking");
        anim.SetBool("isLooking", true);
        if (noteMoving) {
            GameObject.FindGameObjectWithTag("Player").GetComponent<StudentBehaviour>().fail = true;
        }
    }
}