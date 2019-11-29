using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleStatus : MonoBehaviour
{
    [SerializeField] Image victoryDisplay;
    [SerializeField] Image defeatedDisplay;

    private int charactersAlive = 0;
    private int enemiesAlive = 0;

    public void AddAliveCharacterCounter() {
        charactersAlive++;
    }

    public void DecreaseAliveCharacterCounter() {
        charactersAlive--;

        if(charactersAlive <= 0) {
            EndGameScreen("lose");
        }
    }

    public void AddAliveEnemyCounter() {
        enemiesAlive++;
    }

    public void DecreaseAliveEnemyCounter() {
        enemiesAlive--;

        if(enemiesAlive <= 0) {
            EndGameScreen("win");
        }
    }

    private void EndGameScreen(string battleOutcome) {
        StartCoroutine(ShowEndOfGameDisplay(battleOutcome));
    }

    IEnumerator ShowEndOfGameDisplay(string battleOutcome) {
        Image displayToShow = battleOutcome == "win" ? victoryDisplay : defeatedDisplay;

        displayToShow.gameObject.SetActive(true);

        yield return new WaitForSeconds(.5f);
        displayToShow.transform.GetChild(0).gameObject.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        if(battleOutcome == "win") {
            FindObjectOfType<SceneLoader>().LoadWinScreen();
        } else {
            FindObjectOfType<SceneLoader>().LoadMap();
        }
    }

}
