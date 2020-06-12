using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

public class SceneControl : MonoBehaviour{
    
    public LevelSaver levelSaver;
    private const string API_KEY = "2b85497c65763a9ae8cea144f5e272625d0b5c1cdadb09b7";

    public void Start(){
        Appodeal.initialize(API_KEY, Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO, true);
    }

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
