using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private string characterName;
    private float currentHealth;
    private float maxHealth;
    private float currentMana;
    private float maxMana;
    private float strength;
    private float magic;
    private float speed;
    private float vitality;
    private float agility;

    [SerializeField] Text characterNameText;
    [SerializeField] Text maxHealthText;
    [SerializeField] Text currentHealthText;
    [SerializeField] Text maxManaText;
    [SerializeField] Text currentManaText;

    private void Start()
    {
        SetStartingTextFields();
        StartCoroutine(AttackEnemyCoroutine());
    }

    IEnumerator AttackEnemyCoroutine() {
        while(true) {
            yield return new WaitForSeconds(speed);
            var targetEnemy = GetTargetEnemy();
            targetEnemy.DamageEnemy(strength);
        }
    }

    private Enemy GetTargetEnemy() {
        var allEnemies = FindObjectsOfType<Enemy>();
        return allEnemies[Random.Range(0, allEnemies.Length)];
    }

    public void DamagePlayer(float damage) {
        currentHealth -= damage;
        currentHealthText.text = currentHealth.ToString();

        if(currentHealth <= 0) {
            currentHealthText.text = 0.ToString();
            Destroy(gameObject);
        }
    }

    public void HealPlayer(float health) {
        currentHealth += health;
        currentHealthText.text = currentHealth.ToString();
    }

    public void SetPlayerStats(PlayerConfig config) {
        GetComponent<SpriteRenderer>().sprite = config.GetBattleSprite();
        characterName = config.GetName();
        currentHealth = config.GetHealth();
        maxHealth = config.GetHealth();
        currentMana = config.GetMana();
        maxMana = config.GetMana();
        strength = config.GetStrength();
        magic = config.GetMagic();
        speed = config.GetSpeed();
        vitality = config.GetVitality();
        agility = config.GetAgility();
    }

    public void SetStartingTextFields() {
        characterNameText.text = characterName.ToString();
        currentHealthText.text = currentHealth.ToString();
        maxHealthText.text = maxHealth.ToString();
        currentManaText.text = currentMana.ToString();
        maxManaText.text = maxMana.ToString();
    }

    public void DestroyPlayer() {
        Destroy(characterNameText);
        Destroy(maxHealthText);
        Destroy(currentHealthText);
        Destroy(maxManaText);
        Destroy(currentManaText);
        Destroy(gameObject);
    }
}
