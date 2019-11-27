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
    [SerializeField] Sprite battleSprite;
    [SerializeField] Sprite avatar;

    public string GetName() { return characterName; }

    public float GetHealth() {
        return health * PlayerPrefs.GetInt(characterName + "_level", 1);
    }
    public float GetMana() {
        return mana * PlayerPrefs.GetInt(characterName + "_level", 1);
    }
    public float GetStrength() {
        return strength * PlayerPrefs.GetInt(characterName + "_level", 1);;
    }
    public float GetMagic() {
        return magic * PlayerPrefs.GetInt(characterName + "_level", 1);
    }
    public float GetSpeed() {
        return speed / PlayerPrefs.GetInt(characterName + "_level", 1);
    }
    public float GetVitality() {
        return vitality * PlayerPrefs.GetInt(characterName + "_level", 1);
    }
    public float GetAgility() {
        return agility * PlayerPrefs.GetInt(characterName + "_level", 1);
    }

    public Sprite GetBattleSprite() { return battleSprite; }
    public Sprite GetAvatar() { return avatar; }
}
