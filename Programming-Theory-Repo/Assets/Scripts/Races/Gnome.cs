using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class Gnome : CharacterStats
{
    public Gnome()
    {
        //public enum CLASS { Fighter, Cleric, Thief, Fighter_Cleric, Fighter_Thief, Cleric_Thief };
        charRace = RACE.Gnome;
        _magicResistance = 50;
        _charmResistance = 25;
    }

    // POLYMORPHISM
    public static List<string> classNames = new List<string> { "Please select a class", "Fighter", "Cleric", "Thief", "Fighter/Cleric", "Fighter/Thief", "Cleric/Thief" };

    public static int _raceModStrength = 0;
    public static int _raceModDexterity = 0;
    public static int _raceModIntelligence = 1;
    public static int _raceModWisdom = -1;
    public static int _raceModConstitution = 0;
    public static int _raceModCharisma = 0;

}
