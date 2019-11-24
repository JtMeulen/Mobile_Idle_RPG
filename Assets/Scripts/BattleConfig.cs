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
    [SerializeField] EnemyConfig enemy1;
    [SerializeField] EnemyConfig enemy2;
    [SerializeField] EnemyConfig enemy3;

    public string GetBattleName() { return battleName; }
    public float GetGold() { return gold; }
    public float GetExperience() { return experience; }
    public Sprite GetBackgroundSprite() { return backgroundSprite; }
    public EnemyConfig GetEnemy1() { return enemy1; }
    public EnemyConfig GetEnemy2() { return enemy2; }
    public EnemyConfig GetEnemy3() { return enemy3; }
}
