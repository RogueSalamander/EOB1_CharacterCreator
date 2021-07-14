using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elf : Character
{
    public enum CLASS { Fighter, Ranger, Mage, Cleric, Thief, Fighter_Mage, Fighter_Thief, Mage_Thief, Fighter_Mage_Thief };
    public List<string> _class = new List<string> { "Please select a class", "Fighter", "Ranger", "Mage", "Cleric", "Thief", "Fighter/Mage", "Fighter/Thief", "Mage/Thief", "Fighter/Mage/Thief" };


}
