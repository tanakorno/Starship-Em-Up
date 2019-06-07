using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    const int InvunerableTime = 120;

    Player PlayerGO;
    Rigidbody2D rb;
    LifeUI lifeUI;
    PlayGameManager Manager;
    int inv;

    public GameObject ExplosionAnim;
    public GameObject Bullet;
    public float speed;
    public int health;
    public int life;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        SetInvunerable();

        PlayerGO = new Player {
            Speed = speed,
            Reload = 0.1f,
            Health = health,
            Life = life,
            Bullet = Bullet
        };
    }

    void Start() {
        lifeUI = GameObject.FindGameObjectWithTag("LifeTextTag").GetComponent<LifeUI>();
        Manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<PlayGameManager>();
    }

    void Update() {
        if (Time.timeScale == 0) return;

        if (inv > 0) inv--;



        PlayerGO.X = Input.GetAxis("Horizontal"); //* Time.deltaTime;
        PlayerGO.Y = Input.GetAxis("Vertical"); //* Time.deltaTime;
        PlayerGO.Move(rb);
    }

    void OnTriggerEnter2D(Collider2D col) {
        GameObject collider = col.gameObject;

        if (collider.tag == "EnemyShipTag" && inv <= 0) {
            collider.GetComponent<EnemyControl>().Damage(250);
            Damage(250);
        }
    }

    public void AddLife() {
        PlayerGO.UpdateLife(PlayerGO.Life + 1);
        lifeUI.DisplayLife(PlayerGO.Life);
    }

    public void Damage(int v) {
        if (inv <= 0) {
            PlayerGO.DoDamage(v);
        }

        if (PlayerGO.Health <= 0) {
            PlayerGO.Health = health;
            PlayerGO.UpdateLife(PlayerGO.Life - 1);
            lifeUI.DisplayLife(PlayerGO.Life);

            SetInvunerable();
            PlayExplosion();
        }

        if (PlayerGO.Life <= 0) {
            Manager.IsVictory(false);
            Destroy(gameObject);
        }
    }

    void PlayExplosion() {
        GameObject explosion = Instantiate(ExplosionAnim);
        explosion.transform.position = transform.position;
    }

    void SetInvunerable() {
        inv = InvunerableTime;

        Renderer renderer = GetComponent<Renderer>();
        float blink_ratio = 0.05f;
        int total_blink = (int)(inv / 60 / blink_ratio / 2);

        StartCoroutine(DoBlinks(renderer, total_blink, blink_ratio));
    }

    IEnumerator DoBlinks(Renderer renderer, int numBlinks, float seconds) {
        for (int i = 0; i < numBlinks * 2; i++) {
            renderer.enabled = !renderer.enabled;
            yield return new WaitForSeconds(seconds);
        }
        renderer.enabled = true;
    }

}
