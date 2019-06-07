using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour {

    private Text lifeTextUI;

    public int Life;

    void Start() {
        lifeTextUI = GetComponent<Text>();
        DisplayLife(3);
    }

    public void DisplayLife(int v) {
        Life = v;
        lifeTextUI.text = string.Format("{0}", Life);
    }
}