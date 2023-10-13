using Assets.Scripts.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UIElements;

public class Monster : BaseMonster,IPoolable
{

    private Transform player;
    [SerializeField] private LayerMask playerLayer;

    private float Speed = 2;
    private float detectionDistance = 1f;
    public bool IsAttacking = false;
    /// can be changed probably
    private float distanceForAttack = 2f;
    private Vector2 capsuleSize = new Vector2(0.5f, 0.5f);

    public event EventHandler<IPoolable> OnObjectDeactivation;

    private void FixedUpdate()
    {
        ChasePlayer();
    }

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    /// <summary>
    /// /perhaps this will require corrections due to twitching when it hits the player, but after the finished textures
    /// </summary>
    private void ChasePlayer()
    {
        ////may be need to return calculated distanceToPlayer  and after  do attack
        ////and also may be better check for a barrier int other function  and rerun modified direction

        Vector3 direction = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

 

        if (distanceToPlayer < distanceForAttack)
        {
            if (!IsAttacking)
                ObjectDeactivation();
            //    StartCoroutine(Attack());
            return;
        }

        // Check for some barrier in front of monster with shape of a capsule
        var capsule = Physics2D.Raycast(transform.position , direction, detectionDistance, playerLayer);/*transform.position, capsuleSize, CapsuleDirection2D.Vertical, 0, direction, detectionDistance, playerLayer);*/
        Debug.DrawRay(transform.position, direction, Color.red, 5f);



        /////if something is in front  and it is not a player ,   later need  to change PlayerController as component
        if (capsule.collider != null && capsule.collider.transform != player)
        {

            /*/// <summary>
            /// The leftDir and topDir variables are vectors perpendicular to the main direction of movement. These perpendicular vectors are calculated by rotating the original vector 90 degrees around the origin.
            In 2D space, vector  (x, y) can be rotated 90 degrees, resulting in a vector (−y,x) or (y,−x).
            leftDir = new Vector2(-direction.y, direction.x) rotates direction 90 degrees counterclockwise.
            topDir = new Vector2(direction.y, -direction.x) rotates direction 90 degrees clockwise.
            This allows you to check "lateral" directions relative to the main direction of travel.
            /// </summary>*/
            var leftDir = new Vector2(-direction.y,direction.x);
            var topDir = new Vector2(direction.y, -direction.x);
         

            ////throw ray to the left for checking if it's direction is clear;
            var leftRay = Physics2D.Raycast(transform.position, leftDir, detectionDistance, playerLayer);
            Debug.DrawRay(transform.position, leftDir, Color.black, 5f);

            if(leftRay.collider == null)
            {
                direction = leftDir;

            }
            else
            {
                ///throw ray to the top for checking if it's direction is clear;
                var topRay = Physics2D.Raycast(transform.position, topDir, detectionDistance, playerLayer);
                Debug.DrawRay(transform.position, topDir, Color.blue, 5f);


                if(topRay.collider == null)
                {
                    direction = topDir;
                }
                
            }

        }
        transform.position += direction * Speed * Time.deltaTime;

    }





    public override IEnumerator Attack()
    {
        IsAttacking = true;

        yield return new WaitForSeconds(2f);
        player.GetComponent<IAttackable>().TakeDamage(Damage);

        IsAttacking = false;
    }

    public GameObject GetGameObject() => gameObject;

    public void ObjectDeactivation()
    {
        OnObjectDeactivation?.Invoke(this, this);

        IsAttacking = true;
    }

    //public override void Die(),
    //{
    //    throw new System.NotImplementedException();
    //}

    //public override void TakeDamage(int amount)
    //{
    //    throw new System.NotImplementedException();
    //}




}
