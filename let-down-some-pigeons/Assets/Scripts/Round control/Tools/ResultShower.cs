using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultShower : MonoBehaviour{
    
    public Text resultText;
    public GameObject window;

    private SpriteRenderer windowFrame;
    
    private void Start(){
        windowFrame = GetComponent<SpriteRenderer>();  
    }

    public void ShowWinResult(){
        resultText.text = "Вы победили!";
        window.SetActive(true);
        
        //Вот эта фигня написана укропами, не мой код ахах
        for (int i = 0; i < window.transform.childCount; i++){
            window.transform.GetChild(i).gameObject.SetActive(true);
            for (int j = 0; j < window.transform.GetChild(i).childCount; j++)
                window.transform.GetChild(i)
                    .transform.GetChild(j)
                    .gameObject
                    .SetActive(true); 
        }
    }
}
