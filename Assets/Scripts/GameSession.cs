using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    public int activeBattleNumber = 1;

    private void Awake()
    {
        if(FindObjectsOfType(GetType()).Length > 1) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }

    public int GetActiveBattleNumber() {
        return activeBattleNumber;
    }

    public void SetActiveBattleNumber(int batlleNumber) {
        activeBattleNumber = batlleNumber;
    }

    public void SaveBattler1(string name) {
        Debug.Log("Saving: " + name);
        PlayerPrefs.SetString("character_1_battler", name);
    }
    public void SaveBattler2(string name) {
        PlayerPrefs.SetString("character_2_battler", name);
    }
    public void SaveBattler3(string name) {
        PlayerPrefs.SetString("character_3_battler", name);
    }
    public void SaveBattler4(string name) {
        PlayerPrefs.SetString("character_4_battler", name);
    }
    public void SaveBattler5(string name) {
        PlayerPrefs.SetString("character_5_battler", name);
    }
}
