using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Thief : CharacterClass
{
    // POLYMORPHISM
    public Thief()
    {
        useableWeapons = new List<string> { "All" };

        classHitDice = 6;

        thievesToolsProficiency = true;
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
