using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour {

    public GameObject LBLPause;
    public GameObject BTNResume;
    public GameObject BTNBack;

    public bool GameEnd { get; set; }

    void Start() {
        GameEnd = false;
        ActivePause(false);
    }

    void Update() {
        if (GameEnd) return;

        if (Input.GetKeyDown(KeyCode.Escape)
            //|| Input.GetKeyDown(KeyCode.P)
            //|| Input.GetKeyDown(KeyCode.F10)
            ) {

            ActivePause(Time.timeScale == 1);
        }
    }

    public void ActivePause(bool state) {
        Time.timeScale = state ? 0 : 1;

        LBLPause.SetActive(state);
        BTNResume.SetActive(state);
        BTNBack.SetActive(state);
    }
}
