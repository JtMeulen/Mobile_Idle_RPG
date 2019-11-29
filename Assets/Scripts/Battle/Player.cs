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

    // Serialized fields
    [SerializeField] Text characterNameText;
    [SerializeField] Text maxHealthText;
    [SerializeField] Text currentHealthText;
    [SerializeField] Text maxManaText;
    [SerializeField] Text currentManaText;

    private BattleStatus battleStatus;
    private bool battleActive = true;

    private void Start()
    {
        battleStatus = FindObjectOfType<BattleStatus>();
        SetStartingTextFields();
        StartCoroutine(AttackEnemyCoroutine());
    }

    IEnumerator AttackEnemyCoroutine() {
        while(battleActive) {
            yield return new WaitForSeconds(speed);
            var targetEnemy = GetTargetEnemy();

            if(targetEnemy) {
                targetEnemy.DamageEnemy(strength);
                Flash("green");
            }
        }
    }

    private Enemy GetTargetEnemy() {
        var allEnemies = FindObjectsOfType<Enemy>();

        if(allEnemies.Length <= 0) {
            battleActive = false;
            return null;
        }

        return allEnemies[Random.Range(0, allEnemies.Length)];
    }

    private void Flash(string color) {
        // TEMP to test leveling up
        int currentLevel = PlayerPrefs.GetInt(characterName + "_level", 1);
        PlayerPrefs.SetInt(characterName + "_level", currentLevel + 1);

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

    public void DamagePlayer(float damage) {
        currentHealth -= damage;
        currentHealthText.text = currentHealth.ToString();
        Flash("red");

        if(currentHealth <= 0) {
            currentHealthText.text = 0.ToString();
            battleStatus.DecreaseAliveCharacterCounter();
            Destroy(gameObject);
        }
    }

    public void HealPlayer(float health) {
        currentHealth += health;
        currentHealthText.text = currentHealth.ToString();
    }

    //*****   SETTINGS FUNCTIONS   *****//

    // This is called by the BattleController at the beginning of the battle
    public void SetPlayerStats(PlayerConfig config) {
        GetComponent<SpriteRenderer>().sprite = config.GetBattleSprite();
        characterName   = config.GetName();
        currentHealth   = config.GetHealth();
        maxHealth       = config.GetHealth();
        currentMana     = config.GetMana();
        maxMana         = config.GetMana();
        strength        = config.GetStrength();
        magic           = config.GetMagic();
        speed           = config.GetSpeed();
        vitality        = config.GetVitality();
        agility         = config.GetAgility();
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
