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
        PlayerPrefs.SetString("battler_1", name);
    }
    public void SaveBattler2(string name) {
        PlayerPrefs.SetString("battler_2", name);
    }
    public void SaveBattler3(string name) {
        PlayerPrefs.SetString("battler_3", name);
    }
    public void SaveBattler4(string name) {
        PlayerPrefs.SetString("battler_4", name);
    }
    public void SaveBattler5(string name) {
        PlayerPrefs.SetString("battler_5", name);
    }

    public void DeleteSaveData() {
        PlayerPrefs.DeleteAll();
    }
}
