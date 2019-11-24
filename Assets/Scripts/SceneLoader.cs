using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadBattle() {
        SceneManager.LoadScene("Battle");
    }

    public void LoadMap() {
        SceneManager.LoadScene("Map");
    }
}
