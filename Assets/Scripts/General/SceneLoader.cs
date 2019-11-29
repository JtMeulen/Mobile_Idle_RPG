using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadBattle(int battleNumber) {
        PlayerPrefs.SetInt("active_battle", battleNumber);
        SceneManager.LoadScene("Battle");
    }

    public void LoadMap() {
        SceneManager.LoadScene("Map");
    }

    public void LoadWinScreen() {
        SceneManager.LoadScene("Win Screen");
    }

    public void LoadPartyMenu() {
        SceneManager.LoadScene("Party Menu");
    }

    public void LoadSettingsMenu() {
        SceneManager.LoadScene("Settings Menu");
    }
}
