using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Dwarf : CharacterStats
{
    public Dwarf()
    {
        // public enum CLASS { Fighter, Cleric, Thief, Fighter_Cleric, Fighter_Thief };
        charRace = RACE.Dwarf;
        _poisonResistance = 25;
    }

    // POLYMORPHISM
    public static List<string> classNames = new List<string> { "Please select a class", "Fighter", "Cleric", "Thief", "Fighter/Cleric", "Fighter/Thief" };

    public static int _raceModStrength = 0;
    public static int _raceModDexterity = 0;
    public static int _raceModIntelligence = 0;
    public static int _raceModWisdom = 0;
    public static int _raceModConstitution = 1;
    public static int _raceModCharisma = -1;

}
