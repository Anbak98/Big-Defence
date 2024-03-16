using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTower : Tower
{
    public float attackRange = 10f; // Range within which the tower can attack
    public float attackDamage = 10f; // Damage inflicted by each attack
    public float attackCooldown = 1f; // Cooldown between attacks

    private Transform target; // Current target enemy
    private float cooldownTimer = 0f; // Timer for attack cooldown

    protected override void Start()
    {
        base.Start();
    }

    void FindTarget()
    {
        // Find all enemies within attack range
        Collider[] enemies = Physics.OverlapSphere(transform.position, attackRange, LayerMask.GetMask("Enemy"));

        // Pick the first enemy found as the target
        if (enemies.Length > 0)
        {
            target = enemies[0].transform;
        }
        else
        {
            target = null;
        }
    }

    void AttackTarget()
    {
        // Check if attack cooldown has finished
        if (cooldownTimer <= 0f)
        {
            // Attack the target
            DealDamage(target.GetComponent<Enemy>());

            // Reset cooldown timer
            cooldownTimer = attackCooldown;
        }
        else
        {
            // Reduce cooldown timer
            cooldownTimer -= Time.deltaTime;
        }
    }

    void DealDamage(Enemy enemy)
    {
        // Deal damage to the target enemy
        if (enemy != null)
        {
            enemy.TakeDamage(attackDamage);
        }
    }

    // Visualize tower range in Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
} 