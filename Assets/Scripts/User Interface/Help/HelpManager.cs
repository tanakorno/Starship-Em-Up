﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HelpManager : MonoBehaviour {

    public void OnBack() {
        SceneManager.LoadScene("MainMenu");
    }
}
