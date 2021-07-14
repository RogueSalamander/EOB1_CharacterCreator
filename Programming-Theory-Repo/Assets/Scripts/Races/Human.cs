using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Human : Character
{
    public enum CLASS { Fighter, Ranger, Paladin, Mage, Cleric, Thief };
    public List<string> classNames = new List<string>{ "Please select a class", "Fighter", "Ranger", "Paladin", "Mage", "Cleric", "Thief" };

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
