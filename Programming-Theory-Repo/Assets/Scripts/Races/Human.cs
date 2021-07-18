using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
//[System.Serializable]
public class Human : CharacterStats
{
    public Human()
    {
        // CLASS { Fighter, Ranger, Paladin, Mage, Cleric, Thief };
        charRace = RACE.Human;
        
    }
    
    // POLYMORPHISM
    public static List<string> classNames = new List<string> { "Please select a class", "Fighter", "Ranger", "Paladin", "Mage", "Cleric", "Thief" };

// Overriden race modifiers
    public static int _raceModStrength = 0;
    public static int _raceModDexterity = 0;
    public static int _raceModIntelligence = 0;
    public static int _raceModWisdom = 0;
    public static int _raceModConstitution = 0;
    public static int _raceModCharisma = 0;

    

    /*public override List<string> classNames
    {
        get
        {
            return classNames;
        }
        set
        {
            classNames = new List<string>();
        }
    }*/

}
