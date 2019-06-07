using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    protected float delay;
    protected float sreload;
    protected float sfireRate;

    protected float angle;
    protected float cntBullet;

    public GameObject bullet;
    public int maxBullet;
    public float reload;
    public float fireRate;
    public float speed;

    protected void Start() {
        angle = gameObject.transform.eulerAngles.z + 90;

        sreload = reload * 60;
        sfireRate = fireRate * 60;

        delay = 0;
    }

    void Update() {
        if (Time.timeScale == 0) return;

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

    protected void Shoot(float Angle, float Speed) {
        GameObject Temp = Instantiate(bullet, gameObject.transform.position, Quaternion.identity);
        Temp.GetComponent<BulletControl>().SetAngle(Angle);
        Temp.GetComponent<BulletControl>().SetSpeed(Speed);
    }
}
