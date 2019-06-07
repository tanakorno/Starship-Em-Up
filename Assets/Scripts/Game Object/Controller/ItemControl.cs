using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemControl : MonoBehaviour {

    Item itemGO;
    Rigidbody2D rb;

    public float speed;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();

        itemGO = new Item {
            Speed = speed,
            Item_Type = 1
        };
    }

    void Start() {

    }

    void Update() {
        Vector3 moveDir = Quaternion.Euler(0, 0, 270) * Vector3.right;
        rb.velocity = moveDir * speed;
    }

    void OnTriggerEnter2D(Collider2D col) {
        GameObject collider = col.gameObject;

        if (itemGO.CheckCollide(col) == true) {
            collider.GetComponent<PlayerControl>().AddLife();
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
