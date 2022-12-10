using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugalu : Enemy {
    // Start is called before the first frame update

    float x, y;
    float startY;
    public float fireCooldown;
    bool canPlay = false;
    public GameObject bullet;
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

    public GameObject hurt;
    public GameObject died;

    [SerializeField]
    float t = 0;

    public float deathTime = 10;

    public override void Move() {

        if (!inY) {
            this.transform.position = new Vector3(x + Mathf.Sin(t * Xspeed + moveOffset) * amp, Mathf.Lerp(startY, y, Mathf.SmoothStep(0, 1, t * Yspeed)) + Mathf.Sin(t * Xspeed * 3 + moveOffset) * amp / 3);
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

        else{
            this.transform.position = new Vector3(x + Mathf.Sin(t * Xspeed + moveOffset) * amp, y + Mathf.Sin(t * Xspeed * 3 + moveOffset) * amp / 3  );
            if (!canPlay) {
                canPlay = true;
                InvokeRepeating("FireBullet", fireCooldown + moveOffset*2, fireCooldown + moveOffset*2);
                //StartCoroutine(Fire());
            }
        }
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
    IEnumerator Fire() {

        Instantiate(bullet, this.transform.position, bullet.transform.rotation);
        yield return new WaitForSeconds(fireCooldown + moveOffset*2);
    }
    void FireBullet() {
        Instantiate(bullet, this.transform.position, bullet.transform.rotation);
        
    }

    public override void Dmg(int dmg) {
        Instantiate(hurt, this.gameObject.transform.position, hurt.transform.rotation);
        //LeanTween.(0.1f);
        hp-=dmg;
        if(hp<=0){
            //LeanTween.cancel(this.gameObject);
            LeanTween.cancel(this.gameObject);
            death.Invoke();
            death.RemoveAllListeners();
            Instantiate(died, this.gameObject.transform.position, died.transform.rotation);
            GameObject.Destroy(this.gameObject);
        }
        LTSeq seq = LeanTween.sequence();
        seq.append(()=> {LeanTween.color(this.gameObject, Color.red ,0.01f);});
        seq.append(0.1f); 
        seq.append(()=> {LeanTween.color(this.gameObject,Color.white,0.02f);});
    }
}
