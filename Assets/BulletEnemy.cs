using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletEnemy : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log("Bullet hit");

        if(collision.gameObject.TryGetComponent(out PlayerBehaviour player)){
            player.Dmg();
            GameObject.Destroy(this.gameObject);
        }
    }

}
