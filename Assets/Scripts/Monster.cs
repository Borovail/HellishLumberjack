using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Monster : BaseMonster
{


    [SerializeField] private Transform player;
    [SerializeField] private LayerMask playerLayer;

    private float Speed = 2;
    private float detectionDistance = 1f;
    private bool IsAttacking = false;
    /// can be changed probably
    private float distanceForAttack = 1.3f;
    private Vector2 capsuleSize = new Vector2(0.5f, 0.5f);

    private void FixedUpdate()
    {
        ChasePlayer();
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

        if(distanceToPlayer < distanceForAttack)
        {
            if (!IsAttacking) 
           StartCoroutine( Attack());
            return;
        }

        // Check for some barrier in front of monster with shape of a capsule
        var capsule = Physics2D.Raycast(transform.position, direction, detectionDistance, playerLayer);/*transform.position, capsuleSize, CapsuleDirection2D.Vertical, 0, direction, detectionDistance, playerLayer);*/
        Debug.DrawRay(transform.position, direction, Color.red,5f);



        /////if something is in front  and it is not a player ,   later need  to change PlayerController as component
        if (capsule.collider != null && capsule.collider.transform!=player)
        {
            // Compute perpendicular directions
            Vector2 leftPerpendicular = new Vector2(-direction.y, direction.x);
            Vector2 rightPerpendicular = new Vector2(direction.y, -direction.x);

            // Look for vertical direction to get around
            var verticalRay = Physics2D.Raycast(transform.position, leftPerpendicular, detectionDistance, playerLayer);
            Debug.DrawRay(transform.position, leftPerpendicular * detectionDistance, Color.red);

            /////if there is nothing vertically and it is not a player
            if (verticalRay.collider == null )
            {
                direction = new Vector3(direction.x, -direction.y);
            }
            else
            {
                // Look for horizontal direction to get around
                var horizontalRay = Physics2D.Raycast(transform.position, rightPerpendicular, detectionDistance, playerLayer);
                Debug.DrawRay(transform.position, rightPerpendicular * detectionDistance, Color.red);

                /////if there is nothing horizontally and it is not a player
                if (horizontalRay.collider == null )
                {
                    direction = new Vector3(-direction.x, direction.y);
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

    //public override void Die()
    //{
    //    throw new System.NotImplementedException();
    //}

    //public override void TakeDamage(int amount)
    //{
    //    throw new System.NotImplementedException();
    //}




}
