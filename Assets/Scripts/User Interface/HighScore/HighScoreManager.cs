using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighScoreManager : MonoBehaviour {

    public Text nameTextUI;
    public Text scoreTextUI;

    HighScore scr;

    void Start() {
        scr = new HighScore();
        LoadScore();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OnBack();
        }
    }

    public void OnClear() {
        scr.ClearScore();
        LoadScore();
    }

    public void OnBack() {
        SceneManager.LoadScene("MainMenu");
    }

    void LoadScore() {
        nameTextUI.text = scr.GetPlayerName();
        scoreTextUI.text = scr.GetHighScore();
    }
}
