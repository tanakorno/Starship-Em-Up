using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanGun : Gun {

    public int maxFan;
    public int angleRatio;

    private void Update() {
        if (Time.timeScale == 0) return;

        if (delay > sreload) {

            if (delay > sreload + sfireRate) {
                for (int i = -maxFan / 2; i <= maxFan / 2; i++) {
                    Shoot(angle - (i * angleRatio), speed);
                }

                cntBullet++;
                delay = sreload;
            }

            if (cntBullet == maxBullet) {
                cntBullet = 0;
                delay = 0;
            }
        }

        delay++;
    }

}