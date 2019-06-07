using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGameManager : MonoBehaviour {

    public StageControl StageGO;
    public ScoreUI ScoreGO;
    public PauseUI PauseGO;
    public OverUI OverGO;

    void Start() {

    }

    void Update() {
        //if (Input.GetKeyDown(KeyCode.KeypadPlus)) Time.timeScale += 0.25f;
        //if (Input.GetKeyUp(KeyCode.KeypadMinus) && Time.timeScale > 0) Time.timeScale -= 0.25f;
    }

    public void IsVictory(bool state) {
        StageGO.GameEnd = true;
        ScoreGO.GameEnd = true;
        PauseGO.GameEnd = true;
        OverGO.GameEnd = true;

        OverGO.IsVictory(state);
        OverGO.FinalScore = ScoreGO.GetScore();
    }

    public void OnResume() {
        PauseGO.ActivePause(false);
    }

    public void OnBackToMenu() {
        OnResume();
        SceneManager.LoadScene("MainMenu");
    }

    public void OnSubmit() {
        OverGO.UpdateScore();
        OnBackToMenu();
    }
}
