using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLeveling : MonoBehaviour
{
    private void Start() {
        LevelUpCharacters();
    }

    private void LevelUpCharacters() {
        for(int i = 1; i < 6; i++) {
            string playerName = PlayerPrefs.GetString("battler_" + i);
            int currentLevel = PlayerPrefs.GetInt(playerName + "_level", 1);
            PlayerPrefs.SetInt(playerName + "_level", currentLevel + 1);
        }
    }
}
