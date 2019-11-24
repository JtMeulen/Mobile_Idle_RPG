using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Battle Config")]
public class BattleConfig : ScriptableObject
{
    [SerializeField] string battleName;
    [SerializeField] int gold;
    [SerializeField] int experience;
    [SerializeField] Sprite backgroundSprite;
    [SerializeField] Enemy enemy1;
    [SerializeField] Enemy enemy2;
    [SerializeField] Enemy enemy3;

    public string GetBattleName() { return battleName; }
    public float GetGold() { return gold; }
    public float GetExperience() { return experience; }
    public Sprite GetBackgroundSprite() { return backgroundSprite; }
    public Enemy GetEnemy1() { return enemy1; }
    public Enemy GetEnemy2() { return enemy2; }
    public Enemy GetEnemy3() { return enemy3; }
}
