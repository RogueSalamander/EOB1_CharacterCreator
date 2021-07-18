using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Cleric : CharacterClass
{
    // POLYMORPHISM
    public Cleric()
    {
        useableWeapons = new List<string> { "Mace", "Flail", "Staff", "Sling" };

        classHitDice = 8;

        canUsePrayers = true;
    }

    // ABSTRACTION
    public override int RollLevelHitDice()
    {
        int lvlUpHitRoll = UnityEngine.Random.Range(1, classHitDice);
        return lvlUpHitRoll;
    }

    // ABSTRACTION
    public override int GetClassHitDice()
    {
        return classHitDice;
    }
}
