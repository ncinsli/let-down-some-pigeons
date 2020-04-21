using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Простая обертка изменения текста
public class RoundInfoOutput : MonoBehaviour{
    
    private Text labelToOutput;

    private void Start(){
        labelToOutput = GetComponent<Text>();    
    }

    public void SetText(string message){
        labelToOutput.text = message;
    }
}
