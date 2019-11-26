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
            Flash("green");
        }
    }

    private Player GetTargetPlayer() {
        var allPlayers = FindObjectsOfType<Player>();
        return allPlayers[Random.Range(0, allPlayers.Length)];
    }

    private void Flash(string color) {
        StartCoroutine(FlashCharacter(color));
    }

    IEnumerator FlashCharacter(string color) {
        Color flashColor;

        if(color == "green") {
            flashColor = new Color(0,255,0,0.5f);
        } else if (color == "red") {
            flashColor = new Color(255,0,0,0.5f);
        } else {
            flashColor = new Color(255,255,255,1);
        }

        GetComponent<SpriteRenderer>().color = flashColor;
        yield return new WaitForSeconds(0.2f);
        GetComponent<SpriteRenderer>().color = new Color(255,255,255,1);
    }

    //*****   PUBLIC FUNCTIONS   *****//

    public void DamageEnemy(float damage) {
        currentHealth -= damage;
        currentHealthText.text = currentHealth.ToString();
        Flash("red");

        if(currentHealth <= 0) {
            currentHealthText.text = 0.ToString();
            Destroy(gameObject);
        }
    }

    public void HealEnemy(float health) {
        currentHealth += health;
        currentHealthText.text = currentHealth.ToString();
    }

    //*****   SETTINGS FUNCTIONS   *****//

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
