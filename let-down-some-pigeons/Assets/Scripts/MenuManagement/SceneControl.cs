using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour{
    
    public LevelSaver levelSaver;
    ///<summary> Эта штука грузит сцену классическим способом, а конкретнее, без всяких эфеектов </summary>
    public void LoadSceneClassic(string sceneName){
        if (levelSaver.CheckByName(sceneName) > levelSaver.CheckByName(SceneManager.GetActiveScene().name))
            PlayerPrefs.SetInt("SceneIndex", levelSaver.CheckByName(sceneName));
        SceneManager.LoadScene(sceneName); 
        Debug.Log($"SceneINDEX mod: {PlayerPrefs.GetInt("SceneIndex")}     BUILD INDEX: {SceneManager.GetActiveScene().buildIndex}");
        Time.timeScale = 1f; //Для функционирования меню
    }
    //private void OnApplicationQuit() {
        ///<Iseditor> скрипт, чтобы нормально дебажить
      //  if (Application.isEditor){
        //    Debug.Log("SET SCENESAVE TO 0");
          //  PlayerPrefs.SetInt("SceneIndex", 0);    
       // }
    //}
}
