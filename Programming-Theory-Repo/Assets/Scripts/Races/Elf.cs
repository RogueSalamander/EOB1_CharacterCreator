using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Elf : CharacterStats
{
    public Elf()
    {
        // public enum CLASS { Fighter, Ranger, Mage, Cleric, Thief, Fighter_Mage, Fighter_Thief, Mage_Thief, Fighter_Mage_Thief };
        charRace = RACE.Elf;
        _sleepResistance = 100;
    }
    
    // POLYMORPHISM
    public static List<string> classNames = new List<string> { "Please select a class", "Fighter", "Ranger", "Mage", "Cleric", "Thief", "Fighter/Mage", "Fighter/Thief", "Mage/Thief", "Fighter/Mage/Thief" };

    public static int _raceModStrength = 0;
    public static int _raceModDexterity = 1;
    public static int _raceModIntelligence = 0;
    public static int _raceModWisdom = 0;
    public static int _raceModConstitution = -1;
    public static int _raceModCharisma = 0;

}
