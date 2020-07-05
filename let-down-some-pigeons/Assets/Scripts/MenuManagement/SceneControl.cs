using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour{
    
    public LevelSaver levelSaver;
    private const string API_KEY = "2b85497c65763a9ae8cea144f5e272625d0b5c1cdadb09b7";
    private bool consentValue;

    public void Start(){
        consentValue = Convert.ToBoolean(PlayerPrefs.GetInt("Consent"));
#if UNITY_ANDROID && !UNITY_EDITOR        
        Appodeal.initialize(API_KEY, Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO | Appodeal.BANNER, consentValue);
        string n = SceneManager.GetActiveScene().name;
        if (n == "Menu" || n == "Settings") 
            Appodeal.show(Appodeal.BANNER);
        else Appodeal.hide(Appodeal.BANNER);
        Appodeal.disableWriteExternalStoragePermissionCheck();
#endif
    }

    ///<summary> Эта штука грузит сцену классическим способом, а конкретнее, без всяких эфеектов </summary>
    public void LoadSceneClassic(string sceneName){
        if (sceneName != "LevelManager"){
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            if (levelSaver.CheckByName(sceneName) > levelSaver.CheckByName(SceneManager.GetActiveScene().name))
                PlayerPrefs.SetInt("SceneIndex", levelSaver.CheckByName(sceneName));
            SceneManager.LoadScene(sceneName); 
        //  Debug.Log($"SceneINDEX mod: {PlayerPrefs.GetInt("SceneIndex")}     BUILD INDEX: {SceneManager.GetActiveScene().buildIndex}");
            Time.timeScale = 1f; //Для функционирования меню
        }
        else{
            PlayerPrefs.SetString("LastScene", SceneManager.GetActiveScene().name);
            SceneManager.LoadScene(sceneName); 
            Time.timeScale = 1f; //Для функционирования меню
        }
    }

    public void LoadLastScene(){
        string name = PlayerPrefs.GetString("LastScene");
        LoadSceneClassic(name);
    }

   // private void OnApplicationFocus(bool focus) => Debug.Log($"Biggest Level detected: {PlayerPrefs.GetInt("SceneIndex")}");
    //Честно, не знаю. Но это вроде помогает с сохранением
    private void OnDisable() {
        Debug.Log("On disable callback -> " + PlayerPrefs.GetInt("SceneIndex").ToString());
        PlayerPrefs.Save(); 
    }
}
