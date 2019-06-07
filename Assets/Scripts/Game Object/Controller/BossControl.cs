using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossControl : EnemyControl {

    PlayGameManager Manager;
    int delay;

    void Start() {
        scoreUI = GameObject.FindGameObjectWithTag("ScoreTextTag").GetComponent<ScoreUI>();
        Manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<PlayGameManager>();
    }

    void Update() {
        Vector3 moveDir = Quaternion.Euler(0, 0, enemyGO.Angle) * Vector3.right;
        rb.velocity = moveDir * enemyGO.Speed;

        if (delay > 120) {
            enemyGO.Angle = Random.Range(enemyGO.Angle, enemyGO.Angle + 90);
            SetSpeed(5);
            delay = 0;
        }

        delay++;
    }

    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "BoundTag") {
            enemyGO.Angle -= 180;
        }
    }

    void OnBecameInvisible() {
        enemyGO.Angle -= 180;
    }

    void OnDestroy() {
        Manager.IsVictory(true);
    }
}
