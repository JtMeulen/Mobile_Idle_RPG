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

    private BattleStatus battleStatus;
    private bool battleActive = true;

    private void Start()
    {
        battleStatus = FindObjectOfType<BattleStatus>();
        SetStartingTextFields();
        StartCoroutine(AttackPlayerCoroutine());
    }

    IEnumerator AttackPlayerCoroutine() {
        while(battleActive) {
            yield return new WaitForSeconds(speed);
            var targetPlayer = GetTargetPlayer();

            if(targetPlayer) {
                targetPlayer.DamagePlayer(strength);
                GetComponent<Animator>().SetTrigger("Attack");
            }
        }
    }

    private Player GetTargetPlayer() {
        var allPlayers = FindObjectsOfType<Player>();

        if(allPlayers.Length <= 0) {
            battleActive = false;
            return null;
        }

        return allPlayers[Random.Range(0, allPlayers.Length)];
    }

    //*****   PUBLIC FUNCTIONS   *****//

    public void DamageEnemy(float damage) {
        currentHealth -= damage;
        currentHealthText.text = currentHealth.ToString();

        if(currentHealth <= 0) {
            currentHealthText.text = 0.ToString();
            battleStatus.DecreaseAliveEnemyCounter();
            Destroy(gameObject);
        }
    }

    public void HealEnemy(float health) {
        currentHealth += health;
        currentHealthText.text = currentHealth.ToString();
    }

    //*****   SETTINGS FUNCTIONS   *****//

    public void SetEnemyStats(EnemyConfig config) {
        GetComponent<Animator>().runtimeAnimatorController = config.GetBattleAnimator();
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
