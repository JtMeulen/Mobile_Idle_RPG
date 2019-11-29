using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleStatus : MonoBehaviour
{
    [SerializeField] Text victoryText;
    [SerializeField] Text defeatedText;

    public int charactersAlive = 0;
    public int enemiesAlive = 0;

    public void AddAliveCharacterCounter() {
        charactersAlive++;
    }

    public void DecreaseAliveCharacterCounter() {
        charactersAlive--;

        if(charactersAlive <= 0) {
            Debug.Log("Enemies Won!");
            defeatedText.gameObject.SetActive(true);
        }
    }

    public void AddAliveEnemyCounter() {
        enemiesAlive++;
    }

    public void DecreaseAliveEnemyCounter() {
        enemiesAlive--;

        if(enemiesAlive <= 0) {
            Debug.Log("Players Won!");
            victoryText.gameObject.SetActive(true);
        }
    }


}
