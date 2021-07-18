using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// INHERITANCE 
[CreateAssetMenu (menuName = "Character")]
public class Character : ScriptableObject
{
    public enum GENDER { Male, Female };
    public enum RACE { Human, Elf, Half_Elf, Dwarf, Gnome, Halfling };
    public enum CLASS { Cleric, Fighter, Ranger, Mage, Paladin, Thief, Fighter_Cleric, Fighter_Mage, Fighter_Thief, Mage_Thief, Thief_Mage, Cleric_Thief, Cleric_Ranger, Fighter_Mage_Thief, Fighter_Mage_Cleric };
    public enum ALIGNMENT { Lawful_Good, Lawful_Neutral, Lawful_Evil, Neutral_Good, True_Neutral, Neutral_Evil, Chaotic_Good, Chaotic_Neutral, Chaotic_Evil };

    // private List<string> classNames { get; set; }
    //List<string> classNames = new List<string> { };

    // Personal
    public string characterName = "Default";

    //public Ability[] characterAbilities;

    // ENCAPSULATION
    // Changing stats
    public int _MaxHP { get; set; } = 10;
    public int _CurrentHP { get; set; } = 10;

    private int _MaxFood { get; set; } = 100;
    private int _CurrentFood { get; set; } = 100;

    // Character stats
    private int _Strength { get; set; }
    private int _Dexterity { get; set; }
    private int _Intelligence { get; set; }
    private int _Wisdom { get; set; }
    private int _Constitution { get; set; }
    private int _Charisma { get; set; }

    // Max stats
    //[Range(3.0f, 18.0f)]
    private int _maxStrength { get; set; }
    private int _maxDexterity { get; set; }
    private int _maxIntelligence { get; set; }
    private int _maxWisdom { get; set; }
    private int _maxConstitution { get; set; }
    private int _maxCharisma { get; set; }

    // Battle info
    private int _AC { get; set; }

    // Spellcaster info
    private bool canUseMagic { get; set; } = false;
    private bool canUsePrayers { get; set; } = false;

    public virtual void LeftHandAttack()
    {

    }

    public virtual void RightHandAttack()
    {

    }
}
