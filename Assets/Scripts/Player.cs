using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IAttackable
{
   private int Health = 100;
    private int Damage = 10;
    public int Attack() => Damage;



    public void TakeDamage(int amount)
    {
        Debug.Log("player gets hit");

        Health -= amount;

        Debug.Log("player HEAlth after hit: " + Health);


    }


}
