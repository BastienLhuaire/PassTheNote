using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour {
    public Button yourButton;
    public bool changement = false;
    FMOD.Studio.EventInstance sounda;
    FMOD.Studio.EventInstance soundb;


    void Start() {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        sounda = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GestionSound>().sound1;
        soundb = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GestionSound>().sound2;
    }

    void TaskOnClick() {
        sounda.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        soundb.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        SceneManager.LoadScene("Intro", LoadSceneMode.Single);
    }
}