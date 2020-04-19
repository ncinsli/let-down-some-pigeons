using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour{
    
    ///<summary> Эта штука грузит сцену классическим способом, а конкретнее, без всяких эфеектов </summary>
    public void LoadSceneClassic(string sceneName) => SceneManager.LoadScene(sceneName);
    
}
