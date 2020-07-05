using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelSaver", menuName = "let-down-some-pigeons/LevelSaver", order = 0)]
public class LevelSaver : ScriptableObject {
    public string LastLevelName;
    public string BiggestLevelName;
    public int BiggestLevelIndex;

    public void OnEnable(){
        BiggestLevelIndex = PlayerPrefs.GetInt("BiggestLevelIndex");
        //Debug.Log($"Biggest level index is {PlayerPrefs.GetInt("BiggestLevelIndex")}");
        Debug.Log("SCRIPTABLE OBJECT STARTS");
    }
    public int CheckByName(string name){
        int a = -1; //Я уже не знаю, как это работает   
        if (name.Contains("Level")) int.TryParse(name.Substring(name.Length - 2), out a);
        if (a > BiggestLevelIndex) BiggestLevelIndex = a;
        PlayerPrefs.SetInt("BiggestLevelIndex", BiggestLevelIndex);
        return a;
    }

    private void OnDisable(){
        //Debug.Log($"Biggest level index is {PlayerPrefs.GetInt("BiggestLevelIndex")}");
        PlayerPrefs.SetInt("BiggestLevelIndex", BiggestLevelIndex);
    }
    
}
