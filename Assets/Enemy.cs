using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Enemy : MonoBehaviour
{
    public UnityEvent death;
    public int maxHp;
    public int hp;

    public int points;

    [SerializeField]
    public float moveOffset = 0;

    void Update() {
        Move();
    }

    public abstract void Move();
    public abstract void Attack();
    public abstract void SpecialAttack();
    public abstract void Dmg(int dmg);

    public abstract void DieQuick();
}
