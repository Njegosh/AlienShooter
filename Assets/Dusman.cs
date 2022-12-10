using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : Enemy {
    float x, y;
    float startY;

    float startX;

    float fireCooldown;
    bool canPlay = false;
    GameObject bullet;

    void Start() {
        x = this.transform.position.x;// + Mathf.Sin(moveOffset);
        y = this.transform.position.y;
        startY = y + 20;
        startX = x + 20 * Mathf.Sign(moveOffset);
        this.transform.position = new Vector3(startX, startY);
    }
    bool inY = false;
    bool inX = false;

    public float XinSpeed = 3f;
    public float YinSpeed = 3f;

    public float Xspeed = 3f;
    public float Yspeed = 3f;
    public float amp = 10f;

    public GameObject hurt;
    public GameObject died;

    [SerializeField]
    float t = 0;
    public float deathTime = 10;

    public override void Move() {

        if (!inY) {
            this.transform.position = new Vector3(Mathf.Lerp(startX, x, Mathf.SmoothStep(0, 1, t * XinSpeed)), Mathf.Lerp(YinSpeed, y, Mathf.SmoothStep(0, 1, t * Yspeed)));
            if (t * YinSpeed >= 1 && t * XinSpeed >= 1)
                inY = true;
        } else {
            if (!canPlay) {
                canPlay = true;
                StartCoroutine(Fire());
            }

            this.transform.position = new Vector3(x + Mathf.Sin(t * Xspeed + moveOffset) * amp, y + Mathf.Sin(t * Xspeed * 3 + moveOffset) * amp / 3);
            Debug.Log("in position");
        }

        t += Time.deltaTime;
    }

    public override void Attack() {

    }
    public override void SpecialAttack() {

    }

    IEnumerator Fire() {

        Instantiate(bullet, this.transform.position, bullet.transform.rotation);
        yield return new WaitForSeconds(fireCooldown);
    }

    public override void Dmg(int dmg) {
        if (canPlay) {
            Instantiate(hurt, this.gameObject.transform.position, hurt.transform.rotation);
            //LeanTween.(0.1f);
            hp -= dmg;
            if (hp <= 0) {
                //LeanTween.cancel(this.gameObject);
                LeanTween.cancel(this.gameObject);
                death.Invoke();
                death.RemoveAllListeners();
                Instantiate(died, this.gameObject.transform.position, died.transform.rotation);
                GameObject.Destroy(this.gameObject);
            }
            LTSeq seq = LeanTween.sequence();
            seq.append(() => { LeanTween.color(this.gameObject, Color.red, 0.01f); });
            seq.append(0.1f);
            seq.append(() => { LeanTween.color(this.gameObject, Color.white, 0.02f); });
        }
    }
}
