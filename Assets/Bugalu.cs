using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bugalu : Enemy {
    // Start is called before the first frame update

float x,y;

    void Start() {
        x = this.transform.position.x;
        y = this.transform.position.y;
    }
    bool inScene = false;

    public float time = 3f;
    public float amp = 10f;

    [SerializeField]
    float t = 0;

    public float deathTime = 10;

    public override void Move() {

        this.transform.position = new Vector3(x + Mathf.Sin(t + moveOffset)*amp, y);

        t+= Time.deltaTime * time;

        // TODO: FIX OVERFLOW, weird things will happen
        /*
        t = t % 3;
        */
        
        if(t>= deathTime) GameObject.Destroy(this.gameObject);
    }

    public override void Attack() {

    }
    public override void SpecialAttack() {

    }
    public override void Dmg() {

    }
}
