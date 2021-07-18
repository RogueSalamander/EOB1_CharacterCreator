using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Halfling : CharacterStats
{
    public Halfling()
    {
        //public enum CLASS { Fighter, Cleric, Thief, Fighter_Thief };
        charRace = RACE.Halfling;
        _charmResistance = 50;
    }

    // POLYMORPHISM
    public static List<string> classNames = new List<string> { "Please select a class", "Fighter", "Cleric", "Thief", "Fighter/Thief" };

    public static int _raceModStrength = -1;
    public static int _raceModDexterity = 1;
    public static int _raceModIntelligence = 0;
    public static int _raceModWisdom = 0;
    public static int _raceModConstitution = 0;
    public static int _raceModCharisma = 0;

}
