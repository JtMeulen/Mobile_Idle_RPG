using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] Player[] playerPrefabs;
    [SerializeField] PlayerConfig[] playerConfigs;
    [SerializeField] BattleConfig[] battleConfigs;

    [SerializeField] SpriteRenderer background;

    private int ActiveBattleNumber;
    private string[] battlers;

    private void Start() {
        // Get the battlenumber where we can load the right battle config with (name, monster setup)
        ActiveBattleNumber = FindObjectOfType<GameSession>().GetActiveBattleNumber();

        GetListOfCharactersFromSaveFile();
        LoadCharacters();
        LoadBackground();
    }

    private void GetListOfCharactersFromSaveFile()
    {
        battlers = new string[] {
            PlayerPrefs.GetString("battler_1"),
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
                    }
                }
            }
        };
    }

    private void LoadBackground() {
        background.sprite = battleConfigs[ActiveBattleNumber - 1].GetBackgroundSprite();
    }
}
