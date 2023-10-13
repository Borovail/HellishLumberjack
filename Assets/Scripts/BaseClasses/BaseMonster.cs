using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using UnityEngine;

// Abstract class for monsters with basic behavior.
public abstract class BaseMonster : MonoBehaviour
{

    protected int Health =50;
    protected int Damage=5;


    public virtual void Die()
    {

    }

    public abstract IEnumerator Attack();
    public virtual void TakeDamage(int amount) { }


 
}
