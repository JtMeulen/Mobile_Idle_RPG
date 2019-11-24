using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    [SerializeField] Player[] playerPrefabs;
    [SerializeField] PlayerConfig[] playerConfigs;

    private int ActiveBattleNumber;
    private string[] battlers;

    private void Start() {
        // Get the battlenumber where we can load the right battle config with (name, monster setup)
        ActiveBattleNumber = FindObjectOfType<GameSession>().GetActiveBattleNumber();

        GetListOfCharactersFromSaveFile();
        LoadCharacters();
    }

  private void GetListOfCharactersFromSaveFile()
  {
    battlers = new string[] {
        PlayerPrefs.GetString("character_1_battler"),
        PlayerPrefs.GetString("character_2_battler"),
        PlayerPrefs.GetString("character_3_battler"),
        PlayerPrefs.GetString("character_4_battler"),
        PlayerPrefs.GetString("character_5_battler")
    };
  }

  private void LoadCharacters() {
        // Player prefabs to be supplied with the right info
        for(int i = 0; i < playerPrefabs.Length; i++) {
            // loop over the battlers setup to find the right config
            foreach (var config in playerConfigs) {
                if(config.name == battlers[i]) {
                    playerPrefabs[i].SetPlayerStats(config);
                }
            }
        };
    }
}
