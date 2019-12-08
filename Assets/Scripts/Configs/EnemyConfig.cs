using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu(menuName = "Enemy Config")]
public class EnemyConfig : ScriptableObject
{
    [SerializeField] string enemyName;
    [SerializeField] float health;
    [SerializeField] float strength;
    [SerializeField] float magic;
    [SerializeField] float speed;
    [SerializeField] float vitality;
    [SerializeField] float agility;
    [SerializeField] AnimatorController battleAnimator;

    public string GetName() { return enemyName; }
    public float GetHealth() { return health; }
    public float GetStrength() { return strength; }
    public float GetMagic() { return magic; }
    public float GetSpeed() { return speed; }
    public float GetVitality() { return vitality; }
    public float GetAgility() { return agility; }
    public AnimatorController GetBattleAnimator() { return battleAnimator; }
}
