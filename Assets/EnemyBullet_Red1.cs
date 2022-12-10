using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet_Red1 : BulletEnemy
{
    public float speed;
    void Update()
    {
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y - speed * Time.deltaTime);
    }
}
