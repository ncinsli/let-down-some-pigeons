using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSaver", menuName = "let-down-some-pigeons/LevelSaver", order = 0)]
public class LevelSaver : ScriptableObject {
    public string LastLevelName;
    public string BiggestLevelName;
    public int BiggestLevelIndex;
    public int CheckByName(string name){
        int a = -1; 
        if (name.Contains("Level")) int.TryParse(name.Substring(name.Length - 2), out a);
        if (a > BiggestLevelIndex) BiggestLevelIndex = a;
        return a;
    }
    
}
