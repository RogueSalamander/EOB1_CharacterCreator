using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Character : MonoBehaviour
{
    public enum GENDER { Male, Female };
    public enum RACE { Human, Elf, Half_Elf, Dwarf, Gnome, Halfling };
    public enum CLASS { Cleric, Fighter, Ranger, Mage, Paladin, Thief, Fighter_Cleric, Fighter_Mage, Fighter_Thief, Mage_Thief, Thief_Mage, Cleric_Thief, Cleric_Ranger, Fighter_Mage_Thief, Fighter_Mage_Cleric };
    public enum ALIGNMENT { Lawful_Good, Lawful_Neutral, Lawful_Evil, Neutral_Good, True_Neutral, Neutral_Evil, Chaotic_Good, Chaotic_Neutral, Chaotic_Evil };

    // private List<string> classNames { get; set; }
    //List<string> classNames = new List<string> { };

    // Changing stats
    private int _MaxHP { get; set; }
    private int _CurrentHP { get; set; }

    private int _MaxFood { get; set; }
    private int _CurrentFood { get; set; }

    // Character stats
    private int _Strength { get; set; }
    private int _Dexterity { get; set; }
    private int _Intelligence { get; set; }
    private int _Wisdom { get; set; }
    private int _Constitution { get; set; }
    private int _Charisma { get; set; }

    // Battle info
    private int _AC { get; set; }

    // Spellcaster info
    private bool canUseMagic { get; set; } = false;
    private bool canUsePrayers { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void LeftHandAttack()
    {

    }

    public virtual void RightHandAttack()
    {

    }
}
