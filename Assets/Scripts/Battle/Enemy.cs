using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] Text enemyNameText;
    [SerializeField] Text maxHealthText;
    [SerializeField] Text currentHealthText;

    private void Start()
    {
        SetStartingTextFields();
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
        currentHealthText.text = currentHealth.ToString();

        if(currentHealth <= 0) {
            currentHealthText.text = 0.ToString();
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

    public void SetStartingTextFields() {
        enemyNameText.text = enemyName.ToString();
        currentHealthText.text = currentHealth.ToString();
        maxHealthText.text = maxHealth.ToString();
    }

    public void DestroyEnemy() {
        Destroy(enemyNameText);
        Destroy(maxHealthText);
        Destroy(currentHealthText);
        Destroy(gameObject);
    }
}
