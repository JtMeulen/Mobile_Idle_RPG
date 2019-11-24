using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Player Config")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] string characterName;
    [SerializeField] float health;
    [SerializeField] float mana;
    [SerializeField] float strength;
    [SerializeField] float magic;
    [SerializeField] float speed;
    [SerializeField] float vitality;
    [SerializeField] float agility;

    public string GetName() { return characterName; }
    public float GetHealth() { return health; }
    public float GetMana() { return mana; }
    public float GetStrength() { return strength; }
    public float GetMagic() { return magic; }
    public float GetSpeed() { return speed; }
    public float GetVitality() { return vitality; }
    public float GetAgility() { return agility; }
}
