using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour{
    
    ///<summary> Эта штука грузит сцену классическим способом, а конкретнее, без всяких эфеектов </summary>
    public void LoadSceneClassic(string sceneName){ 
        if (PlayerPrefs.GetInt("SceneIndex") < Application.loadedLevel)
            PlayerPrefs.SetInt("SceneIndex", Application.loadedLevel);
        Debug.Log(PlayerPrefs.GetInt("SceneIndex"));
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f; //Для функционирования меню
    }
}
