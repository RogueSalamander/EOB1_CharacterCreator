using System.Collections.Generic;
using UnityEngine;

// ENCAPSULATION
public class CharacterStats : MonoBehaviour
{
    public string characterName = "Default";

    public enum GENDER { Male, Female };
    public enum RACE { Human, Elf, Half_Elf, Dwarf, Gnome, Halfling };
    public enum CLASS { Cleric, Fighter, Ranger, Mage, Paladin, Thief, Fighter_Cleric, Fighter_Mage, Fighter_Thief, Mage_Thief, Thief_Mage, Cleric_Thief, Cleric_Ranger, Fighter_Mage_Thief, Fighter_Mage_Cleric };
    public enum ALIGNMENT { Lawful_Good, Lawful_Neutral, Lawful_Evil, Neutral_Good, True_Neutral, Neutral_Evil, Chaotic_Good, Chaotic_Neutral, Chaotic_Evil };

    public GENDER charGender;
    public RACE charRace;
    public CLASS charClass;
    public ALIGNMENT charAlignment;

    public static List<string> classNames;

    public Stat damageLeftHand;
    public Stat damageRightHand;
    public Stat THAC_LeftHand;
    public Stat THAC_RightHand;
    public Stat armourClass;

    public int maxHealth = 10;
    public int currentHealth { get; private set; }

    public int maxFood = 100;
    public int currentFood { get; private set; }


    public int _strength;
    public int _dexterity;
    public int _intelligence;
    public int _wisdom;
    public int _constitution;
    public int _charisma;

    public int _poisonResistance;
    public int _magicResistance;
    public int _charmResistance;
    public int _sleepResistance;


    private void Awake()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        damage -= armourClass.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + " takes " + damage + " damage." );

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    /*public virtual void UpdateRacialBonuses(int strBonus, int dexBonus, int intBonus, int wisBonus, int conBonus, int chrBonus)
    {
        _raceModStrength = strBonus;
        _raceModDexterity = dexBonus;
        _raceModIntelligence = intBonus;
        _raceModWisdom = wisBonus;
        _raceModContitution = conBonus;
        _raceModCharisma = chrBonus;
    }*/

    // ABSTRACTION
    public virtual void Die()
    {
        // Die in some way
        // This method is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }

    /*public void SetStartingStats(int sStr, int sDex, int sInt, int sWis, int sCon, int sChr)
    {
        _strength = sStr;
    }*/

}
