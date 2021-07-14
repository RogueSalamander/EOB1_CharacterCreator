using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dwarf : Character
{
    public enum CLASS { Fighter, Cleric, Thief, Fighter_Cleric, Fighter_Thief };
    public List<string> _class = new List<string> { "Please select a class", "Fighter", "Cleric", "Thief", "Fighter/Cleric", "Fighter/Thief" };

}
