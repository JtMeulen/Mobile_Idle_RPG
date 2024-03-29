﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleController : MonoBehaviour
{
    [Header("Configs and Prefabs")]
    [SerializeField] Player[] playerPrefabs;
    [SerializeField] Enemy[] enemyPrefabs;
    [SerializeField] PlayerConfig[] playerConfigs;
    [SerializeField] BattleConfig[] battleConfigs;

    [Header("GameObjects")]
    [SerializeField] SpriteRenderer background;
    [SerializeField] Text titleText;

    private BattleConfig activeBattleConfig;
    private BattleStatus battleStatus;
    private string[] battlers;

    private void Start() {
        battleStatus = GetComponent<BattleStatus>();
        SetActiveBattleConfig();
        GetListOfCharactersFromSaveFile();
        LoadCharacters();
        LoadEnemies();
        LoadBackground();
        LoadBattleTitle();
    }

    private void SetActiveBattleConfig() {
        // Get the battlenumber where we can load the right battle config with (name, monster setup)
        int activeBattleNumber = PlayerPrefs.GetInt("active_battle", 1); // default value, incase something goes wrong
        activeBattleConfig = battleConfigs[activeBattleNumber - 1];
    }

    private void GetListOfCharactersFromSaveFile() {
        battlers = new string[] {
            PlayerPrefs.GetString("battler_1", "Warrior"), // default value, incase something goes wrong
            PlayerPrefs.GetString("battler_2"),
            PlayerPrefs.GetString("battler_3"),
            PlayerPrefs.GetString("battler_4"),
            PlayerPrefs.GetString("battler_5")
        };
    }

    private void LoadCharacters() {
        // Player prefabs to be supplied with the right info
        for(int i = 0; i < playerPrefabs.Length; i++) {
            // check if the player is set, otherwise destroy the gameObject
            if(String.IsNullOrEmpty(battlers[i])) {
                playerPrefabs[i].DestroyPlayer();
            } else {
                // loop over the battlers setup to find the right config
                foreach (var config in playerConfigs) {
                    if(config.name == battlers[i]) {
                        playerPrefabs[i].SetPlayerStats(config);
                        battleStatus.AddAliveCharacterCounter();
                    }
                }
            }
        };
    }

    private void LoadEnemies() {
        enemyPrefabs[0].SetEnemyStats(activeBattleConfig.GetEnemy1());
        enemyPrefabs[1].SetEnemyStats(activeBattleConfig.GetEnemy2());
        enemyPrefabs[2].SetEnemyStats(activeBattleConfig.GetEnemy3());

        // TODO: Fix that this is dynamic based on the amount of enemies set
        for(int i = 0; i < 3; i++) {
            battleStatus.AddAliveEnemyCounter();
        }
    }

    private void LoadBackground() {
        background.sprite = activeBattleConfig.GetBackgroundSprite();
    }

    private void LoadBattleTitle() {
        titleText.text = activeBattleConfig.GetBattleName();
    }
}
