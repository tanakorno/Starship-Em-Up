using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour {

    Rigidbody2D rb;
    float Angle;
    float Speed;

    public GameObject ExplosionAnim;
    public int Damage;
    public bool Freeze;

    public void SetAngle(float value) {
        Angle = value % 360;
        if (!Freeze) {
            gameObject.transform.eulerAngles = new Vector3(0, 0, Angle - 90);
        }
    }

    public float GetSpeed() { return Speed; }
    public void SetSpeed(float value) { Speed = value; }

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }   

    void Start() {

    }

    void Update() {
        Vector3 dir = Quaternion.Euler(0, 0, Angle) * Vector3.right;
        rb.velocity = dir * Speed;
    }

    void OnTriggerEnter2D(Collider2D col) {

        GameObject collider = col.gameObject;

        if (collider.tag == "EnemyShipTag" && gameObject.tag == "PlayerBulletTag") {
            collider.GetComponent<EnemyControl>().Damage(Damage);
            DestroyOnCollide();
        } else if (collider.tag == "PlayerShipTag" && gameObject.tag == "EnemyBulletTag") {
            collider.GetComponent<PlayerControl>().Damage(Damage);
            DestroyOnCollide();
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    void DestroyOnCollide() {
        Destroy(gameObject);
        PlayExplosion();
    }

    void PlayExplosion() {
        GameObject explosion = Instantiate(ExplosionAnim);
        explosion.transform.position = transform.position;
    }
}
