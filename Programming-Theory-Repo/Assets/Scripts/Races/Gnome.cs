using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gnome : Character
{
    public enum CLASS { Fighter, Cleric, Thief, Fighter_Cleric, Fighter_Thief, Cleric_Thief };
    public List<string> _class = new List<string> { "Please select a class", "Fighter", "Cleric", "Thief", "Fighter/Cleric", "Fighter/Thief", "Cleric/Thief"  };

}
