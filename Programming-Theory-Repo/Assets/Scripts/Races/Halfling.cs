using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Halfling : Character
{
    public enum CLASS { Fighter, Cleric, Thief, Fighter_Thief };
    public List<string> _class = new List<string> { "Please select a class", "Fighter", "Cleric", "Thief", "Fighter/Thief" };

}
