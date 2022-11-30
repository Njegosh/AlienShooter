using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugalu : Enemy {
    // Start is called before the first frame update

    float x, y;
    float startY;

    void Start() {
        x = this.transform.position.x;// + Mathf.Sin(moveOffset);
        y = this.transform.position.y;
        startY = y + 15;
        this.transform.position = new Vector3(x, startY);
    }
    bool inY = false;
    bool inX = false;

    public float Xspeed = 3f;
    public float Yspeed = 3f;
    public float amp = 10f;

    [SerializeField]
    float t = 0;

    public float deathTime = 10;

    public override void Move() {

        if (!inY) {
            this.transform.position = new Vector3(x + Mathf.Sin(t * Xspeed + moveOffset) * amp, Mathf.Lerp(startY, y, Mathf.SmoothStep(0, 1, t * Yspeed)));
            if (t * Yspeed >= 1) 
                inY = true;
        } 
        /*else {
            if (!inX) {
                if (Mathf.Abs(Mathf.Sin(t * Xspeed + moveOffset) * amp) < 0.1) {
                    inX = true;
                }
            } else {
                this.transform.position = new Vector3(x + Mathf.Sin(t * Xspeed + moveOffset) * amp, y);
            }
        }*/

        else
            this.transform.position = new Vector3(x + Mathf.Sin(t * Xspeed + moveOffset) * amp, y);

        t += Time.deltaTime;

        // TODO: FIX OVERFLOW, weird things will happen
        /*
        t = t % 3;
        */

        //if(t>= deathTime) GameObject.Destroy(this.gameObject);
    }

    public override void Attack() {

    }
    public override void SpecialAttack() {

    }
    public override void Dmg(int dmg) {
        hp-=dmg;
        if(hp<=0){
            death.Invoke();
            GameObject.Destroy(this.gameObject);
        }
    }
}
