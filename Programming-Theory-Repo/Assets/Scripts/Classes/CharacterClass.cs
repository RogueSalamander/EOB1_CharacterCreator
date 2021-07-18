using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ENCAPSULATION
public abstract class CharacterClass : MonoBehaviour
{
    // ENCAPSULATION
    public int currentClassLevel { get; set; } = 1;
    public int maxClassLevel { get; set; } = 20;
    public int currentEXP { get; set; } = 0;
    public int nextLevelEXP { get; set; }
    public float classEXPMultiplier { get; set; } = 1.0f;
    public static int classHitDice;
    public List<string> useableWeapons = new List<string>();

    // Spellcaster info
    public bool canUseMagic { get; set; } = false;
    public bool canUsePrayers { get; set; } = false;
    public bool thievesToolsProficiency { get; set; } = false;
    public bool bowProficiency { get; set; } = false;

    // ABSTRACTION --?
    public virtual int RollLevelHitDice()
    {
        int lvlUpHitRoll = UnityEngine.Random.Range(1, classHitDice);
        return lvlUpHitRoll;
    }

    // ABSTRACTION --?
    public virtual int GetClassHitDice()
    {
        return classHitDice;
    }

    public int GetClassLevel ()
    {
        return currentClassLevel;
    }

    // ABSTRACTION
    public abstract class LeftHandAttack
    {
        
    }
    // ABSTRACTION
    public abstract class RightHandAttack
    {

    }
}
