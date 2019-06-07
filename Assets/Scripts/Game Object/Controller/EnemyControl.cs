using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour {

    bool addedScore;
    bool sleep;

    protected Enemy enemyGO;
    protected Rigidbody2D rb;
    protected ScoreUI scoreUI;

    public GameObject ExplosionAnim;
    public float speed;
    public int health;
    public int score;
    public float decray;

    void Awake() {
        addedScore = false;
        sleep = false;

        rb = GetComponent<Rigidbody2D>();

        enemyGO = new Enemy {
            Speed = speed,
            Reload = 0.1f,
            Health = health,
            Angle = transform.eulerAngles.z + 90
        };
    }

    void Start() {
        scoreUI = GameObject.FindGameObjectWithTag("ScoreTextTag").GetComponent<ScoreUI>();
    }

    void Update() {
        if (Time.timeScale == 0) return;

        Vector3 moveDir;

        if (!sleep) {
            enemyGO.Speed -= decray;
        } else {
            enemyGO.Speed += decray;
        }

        if (enemyGO.Speed < 0) {
            sleep = true;
        }

        moveDir = Quaternion.Euler(0, 0, enemyGO.Angle) * Vector3.right;
        rb.velocity = moveDir * enemyGO.Speed;

    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void PlayExplosion() {
        GameObject explosion = Instantiate(ExplosionAnim);
        explosion.transform.position = transform.position;
    }

    public void SetFacing(float value) {
        enemyGO.ChangeAngle(value);
        transform.eulerAngles = new Vector3(0, 0, enemyGO.Angle - 90);
    }

    public void SetSpeed(float v) {
        enemyGO.Speed = v;
    }

    public void Damage(int v) {
        enemyGO.DoDamage(v);

        if (enemyGO.Health <= 0) {

            PlayExplosion();
            Destroy(gameObject);

            if (!addedScore) {
                addedScore = true;
                scoreUI.AddScore(score);
            }
        }
    }
}
