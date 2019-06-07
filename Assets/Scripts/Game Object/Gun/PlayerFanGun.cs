using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFanGun : FanGun {

    void Update() {
        if (Time.timeScale == 0) return;

        if (Input.GetKey(KeyCode.Space)) {
            if (delay > sreload) {
                for (int i = -maxFan / 2; i <= maxFan / 2; i++) {
                    Shoot(angle - (i * angleRatio), speed);
                }
                delay = 0;
            }
        }

        delay++;
    }
}
