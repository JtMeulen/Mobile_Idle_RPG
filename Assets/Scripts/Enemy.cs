using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100f;
    [SerializeField] float mana = 30f;

    [SerializeField] float attackStrength = 15f;
    [SerializeField] float attackSpeed = 3f;

    private void Start()
    {
        StartCoroutine(AttackPlayerCoroutine());
    }

    IEnumerator AttackPlayerCoroutine() {
        while(true) {
            yield return new WaitForSeconds(attackSpeed);
            var targetPlayer = GetTargetPlayer();
            targetPlayer.DamagePlayer(attackStrength);
        }
    }

    private Player GetTargetPlayer() {
        var allPlayers = FindObjectsOfType<Player>();
        return allPlayers[Random.Range(0, allPlayers.Length)];
    }

    public void DamageEnemy(float damage) {
        health -= damage;

        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    public void HealEnemy(float health) {
        health += health;
    }
}
