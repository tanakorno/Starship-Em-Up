using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {
    
    Stage stage;
    Text scoreTextUI;
    int autoInc;
    
    public bool GameEnd { get; set; }

    public int GetScore() {
        return stage.Score;
    }

    void Start() {
        stage = new Stage();
        scoreTextUI = GetComponent<Text>();
        GameEnd = false;
    }

    void Update() {

        if (Time.timeScale == 0) return;
        if (GameEnd) return;
    }

    public void AddScore(int v) {
        stage.Score += v;
        scoreTextUI.text = string.Format("{0:00000000}", stage.Score);
    }
}