using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Mage : CharacterClass
{
    // POLYMORPHISM
    public Mage()
    {
        useableWeapons = new List<string> { "Dagger", "Staff", "Dart" };

        classHitDice = 4;

        canUseMagic = true;
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
