using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingGun : Gun {

    void Update() {
        if (Time.timeScale == 0) return;

        GameObject player = GameObject.FindGameObjectWithTag("PlayerShipTag");

        if (player == null) return;

        angle = FindAngle(gameObject, player);

        if (delay > sreload) {

            if (delay > sreload + sfireRate) {
                Shoot(angle, speed);
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

    float FindAngle(GameObject Start, GameObject Target) {
        Vector3 start = Start.transform.position;
        Vector3 target = Target.transform.position;
        return Mathf.Atan2(target.y - start.y, target.x - start.x) * Mathf.Rad2Deg;
    }
}
