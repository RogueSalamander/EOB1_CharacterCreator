using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Fighter : CharacterClass
{
    // POLYMORPHISM
    public Fighter ()
    {
        useableWeapons = new List<string>{ "All" };

        classHitDice = 10;

        bowProficiency = true;
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
