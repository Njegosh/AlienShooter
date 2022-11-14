using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int maxHp;
    public int hp;

    [SerializeField]
    public float moveOffset = 0;

    void Update() {
        Move();
    }

    public abstract void Move();
    public abstract void Attack();
    public abstract void SpecialAttack();
    public abstract void Dmg();
}
