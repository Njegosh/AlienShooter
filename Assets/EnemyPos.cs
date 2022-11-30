using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyPos 
{
    public Enemy enemy;
    public int x;

    public int y;

    public float offset;

    public Vector3 toWorldPos(){
        return new Vector2((float)x * 1.25f, (float)y*1.25f + 2);
    }
}
