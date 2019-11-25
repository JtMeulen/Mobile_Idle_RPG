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

    public void LoadPartyMenu() {
        SceneManager.LoadScene("Party Menu");
    }
}
