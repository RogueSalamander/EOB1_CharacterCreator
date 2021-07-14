using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfElf : Character
{
    public enum CLASS { Fighter, Ranger, Mage, Cleric, Thief, Fighter_Cleric, Fighter_Mage, Fighter_Thief, Cleric_Ranger, Cleric_Mage, Thief_Mage, Fighter_Mage_Cleric, Fighter_Mage_Thief };
    public List<string> _class = new List<string> { "Please select a class", "Fighter", "Ranger", "Mage", "Cleric", "Thief", "Fighter/Cleric", "Fighter/Mage", "Fighter/Thief", "Cleric/Ranger", "Cleric/Mage", "Thief/Mage", "Fighter/Mage/Cleric", "Fighter/Mage/Thief" };

}
