using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OverUI : MonoBehaviour {

    HighScore scr;
    int delay;
    string endText;

    public GameObject LBLOver;
    public GameObject LBLFinalScore;
    public GameObject LBLNewScore;
    public GameObject BOXName;
    public GameObject BTNBack;
    public GameObject BTNSubmit;

    public int FinalScore { get; set; }
    public bool GameEnd { get; set; }

    public string PlayerName() {
        string name = BOXName.GetComponent<InputField>().text;
        return name == string.Empty ? "NONAME" : name;
    }

    void Start() {
        scr = new HighScore();
        GameEnd = false;
        ActiveOver(false);
    }

    void Update() {
        if (!GameEnd) return;

        if (delay >= 120) {
            DisplayUI();
        }

        delay++;
    }

    public void IsVictory(bool state) {
        if (state == true) {
            endText = "V i c to r y";
        } else {
            endText = "D e f e a te d";
        }
    }

    public void ActiveOver(bool state) {
        LBLOver.SetActive(state);
        LBLFinalScore.SetActive(state);

        // new highscore
        LBLNewScore.SetActive(state);
        BOXName.SetActive(state);
        BTNSubmit.SetActive(state);

        // nothing
        BTNBack.SetActive(state);
    }

    public void DisplayUI() {
        LBLOver.GetComponent<Text>().text = endText;
        LBLFinalScore.GetComponent<Text>().text = string.Format("Score : {0}", FinalScore);
        ActiveOver(true);

        if (scr.CheckForUpdate(FinalScore) == false) {
            LBLNewScore.SetActive(false);
            BOXName.SetActive(false);
            BTNSubmit.SetActive(false);
        } else {
            BTNBack.SetActive(false);
        }
    }

    public void UpdateScore() {
        scr.UpdateHighScore(PlayerName(), FinalScore);
    }
}
