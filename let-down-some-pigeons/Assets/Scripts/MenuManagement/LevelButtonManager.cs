using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButtonManager : MonoBehaviour{

    public LevelSaver levelSaver;
    public int SceneIndex;
    private Button button;
    private GameObject child;

    private void Start(){
        ///<WARNING!> Если это включить, все сохранения удалятся и будут удаляться при запуске!
        ///PlayerPrefs.SetInt("SceneIndex", 0);
        button = GetComponent<Button>();
        child = transform.GetChild(0).gameObject;
        ///<WORKIMPORTANT!> Число -3 тут - количество сцен помимо самих уровней
        if (SceneIndex > PlayerPrefs.GetInt("SceneIndex") && SceneIndex > 1) //3- сцены помимо уровней
            DeactivateUIElement(new GameObject[] {gameObject, child});
    }

    private void DeactivateUIElement(GameObject[] objects){
        foreach (GameObject obj in objects){
            if (obj.GetComponent<Button>() != null) obj.GetComponent<Button>().interactable = false;
            else if (obj.GetComponent<Image>() != null) obj.GetComponent<Image>().color = new Color32(150, 150, 150, 150);
        }
    }

}
