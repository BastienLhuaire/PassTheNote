using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionSound : MonoBehaviour {
    public FMOD.Studio.EventInstance sound1;
    public FMOD.Studio.EventInstance sound2;
    public int anger;
    // Use this for initialization
    void Start() {
        anger = GameObject.Find("Teacher").GetComponent<Teacher>().soundLevel;
        sound1 = FMODUnity.RuntimeManager.CreateInstance("event:/Music/Musique");
        sound2 = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Chatting");

            sound1.start();
            sound1.setParameterValue("AngerLevel", anger);

            sound2.start();
            sound2.setParameterValue("AngerLevel", anger);

	}
}
