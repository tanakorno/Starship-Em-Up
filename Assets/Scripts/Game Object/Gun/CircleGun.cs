using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleGun : Gun {

    public int Direction;
    public float AngleRatio;

    void Update() {
        if (Time.timeScale == 0) return;

        if (delay > sreload) {

            if (delay > sreload + sfireRate) {

                for (int i = 0; i < Direction; i++) {
                    Shoot(angle + (i * (360 / Direction)), speed);
                }

                angle += AngleRatio % 360;

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
