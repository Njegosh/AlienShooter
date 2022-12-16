using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusman : Enemy {
    float x, y;
    float startY;

    float startX;

    [SerializeField]float fireCooldown;
    [SerializeField]float fireCooldown2;
    bool canPlay = false;
    public GameObject bullet;

    void Start() {
        x = this.transform.position.x;// + Mathf.Sin(moveOffset);
        y = this.transform.position.y;
        startY = y + 10;

        startX = x + 5 * Mathf.Sign(x);
        this.transform.position = new Vector3(startX, startY);
    }
    bool inY = false;
    bool inX = false;

    public float InSpeed = 3f;
    public float startMovingSpeed = 2f;

    public float Xspeed = 3f;
    public float Yspeed = 3f;
    public float amp = 10f;

    float ampUse = 0;

    public GameObject hurt;
    public GameObject died;

    [SerializeField]
    float t = 0;
    public float deathTime = 10;

    public override void Move() {

        if (!inY) {
            this.transform.position = new Vector3(
                Mathf.Lerp(startX, x, Mathf.SmoothStep(0, 1, t * InSpeed)) + Mathf.Sin(t * Xspeed + moveOffset) * ampUse,
                Mathf.Lerp(startY, y, Mathf.SmoothStep(0, 1, t * InSpeed)) + Mathf.Sin(t * Xspeed * 3 + moveOffset) * ampUse / 3);
            if (t * InSpeed >= 1)
                inY = true;
        } else {
            if (!canPlay) {
                canPlay = true;
                InvokeRepeating("FireBullet", fireCooldown, fireCooldown + moveOffset*2);
                InvokeRepeating("FireBullet", fireCooldown + fireCooldown2, fireCooldown + moveOffset*2);
                t=0;
            }
            if(ampUse!=amp)
            ampUse = Mathf.SmoothStep(0, amp, t * startMovingSpeed);

            this.transform.position = new Vector3(x + Mathf.Sin(t * Xspeed + moveOffset) * ampUse,
                                                  y + Mathf.Sin(t * Xspeed * 3 + moveOffset) * ampUse / 3);
            Debug.Log("in position");
        }

        t += Time.deltaTime;

    }

    public override void Attack() {

    }
    public override void SpecialAttack() {

    }

    void FireBullet() {
        Instantiate(bullet, this.transform.position, bullet.transform.rotation);
        
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
