using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class HalfElf : CharacterStats
{
    public HalfElf()
    {
        //public enum CLASS { Fighter, Ranger, Mage, Cleric, Thief, Fighter_Cleric, Fighter_Mage, Fighter_Thief, Cleric_Ranger, Cleric_Mage, Thief_Mage, Fighter_Mage_Cleric, Fighter_Mage_Thief };
        charRace = RACE.Half_Elf;
        _sleepResistance = 50;

    }

    // POLYMORPHISM
    public static List<string> classNames = new List<string> { "Please select a class", "Fighter", "Ranger", "Mage", "Cleric", "Thief", "Fighter/Cleric", "Fighter/Mage", "Fighter/Thief", "Cleric/Ranger", "Cleric/Mage", "Thief/Mage", "Fighter/Mage/Cleric", "Fighter/Mage/Thief" };

    public static int _raceModStrength = 0;
    public static int _raceModDexterity = 0;
    public static int _raceModIntelligence = 0;
    public static int _raceModWisdom = 0;
    public static int _raceModConstitution = 0;
    public static int _raceModCharisma = 0;

}
