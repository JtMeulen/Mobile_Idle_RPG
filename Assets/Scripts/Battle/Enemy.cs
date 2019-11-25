using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private string enemyName;
    private float currentHealth;
    private float maxHealth;
    private float currentMana;
    private float maxMana;
    private float strength;
    private float magic;
    private float speed;
    private float vitality;
    private float agility;

    private void Start()
    {
        StartCoroutine(AttackPlayerCoroutine());
    }

    IEnumerator AttackPlayerCoroutine() {
        while(true) {
            yield return new WaitForSeconds(speed);
            var targetPlayer = GetTargetPlayer();
            targetPlayer.DamagePlayer(strength);
        }
    }

    private Player GetTargetPlayer() {
        var allPlayers = FindObjectsOfType<Player>();
        return allPlayers[Random.Range(0, allPlayers.Length)];
    }

    public void DamageEnemy(float damage) {
        currentHealth -= damage;

        if(currentHealth <= 0) {
            Destroy(gameObject);
        }
    }

    public void HealEnemy(float health) {
        currentHealth += health;
    }

    public void SetEnemyStats(EnemyConfig config) {
        GetComponent<SpriteRenderer>().sprite = config.GetBattleSprite();
        enemyName = config.GetName();
        currentHealth = config.GetHealth();
        maxHealth = config.GetHealth();
        strength = config.GetStrength();
        magic = config.GetMagic();
        speed = config.GetSpeed();
        vitality = config.GetVitality();
        agility = config.GetAgility();
    }

    // public void SetStartingTextFields() {
    //     characterNameText.text = characterName.ToString();
    //     currentHealthText.text = currentHealth.ToString();
    //     maxHealthText.text = maxHealth.ToString();
    // }

    // public void DestroyPlayer() {
    //     Destroy(characterNameText);
    //     Destroy(maxHealthText);
    //     Destroy(currentHealthText);
    //     Destroy(gameObject);
    // }
}
