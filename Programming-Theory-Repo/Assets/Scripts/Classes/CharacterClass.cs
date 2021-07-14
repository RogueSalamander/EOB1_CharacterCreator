using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterClass : MonoBehaviour
{
    private int currentClassLevel { get; set; } = 1;
    private int maxClassLevel { get; set; } = 20;
    private int currentEXP { get; set; } = 0;
    private int nextLevelEXP { get; set; }
    private int classEXPMultiplier { get; set; } = 1;
}
