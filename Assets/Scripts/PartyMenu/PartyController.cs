using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyController : MonoBehaviour
{
    [Header("Player Configs")]
    [SerializeField] PlayerConfig[] playerConfigs;

    [Header("Text Fields")]
    [SerializeField] Text playerName;
    [SerializeField] Text className;
    [SerializeField] Text health;
    [SerializeField] Text mana;
    [SerializeField] Text strength;
    [SerializeField] Text magic;
    [SerializeField] Text speed;
    [SerializeField] Text vitality;
    [SerializeField] Text agility;

    [Header("Active Character Images")]
    [SerializeField] Image[] activeCharacterContainers;

    private string activePlayerName = "Warrior";
    private PlayerConfig activePlayerConfig;

    private void Start() {
        LoadActiveCharacterFromSave();
        FindPlayerInConfigsAndDisplayText();
    }

    private void LoadActiveCharacterFromSave() {
        // Get each of the 5 saved characters and load them in the active bar
        for(int i = 1; i < 6; i++) {
            foreach (var config in playerConfigs) {
                if(config.name == PlayerPrefs.GetString("battler_" + i)) {
                    activeCharacterContainers[i - 1].sprite = config.GetAvatar();
                }
            }
        }
    }

    private void FindPlayerInConfigsAndDisplayText() {
        foreach (var config in playerConfigs) {
            if(config.name == activePlayerName) {
                activePlayerConfig = config;
                DisplayPlayerStats();
            }
        }
    }

    private void DisplayPlayerStats() {
        playerName.text = activePlayerConfig.GetName().ToString();
        className.text = "Classname";
        health.text = activePlayerConfig.GetHealth().ToString();
        mana.text = activePlayerConfig.GetMana().ToString();
        strength.text = activePlayerConfig.GetStrength().ToString();
        magic.text = activePlayerConfig.GetMagic().ToString();
        speed.text = activePlayerConfig.GetSpeed().ToString();
        vitality.text = activePlayerConfig.GetVitality().ToString();
        agility.text = activePlayerConfig.GetAgility().ToString();
    }

    public void SetActivePlayer(string player) {
        activePlayerName = player;
        FindPlayerInConfigsAndDisplayText();
    }

    public void SaveAsActiveBattler(int position) {
        PlayerPrefs.SetString("battler_" + position, activePlayerName);
        LoadActiveCharacterFromSave();
    }
}
