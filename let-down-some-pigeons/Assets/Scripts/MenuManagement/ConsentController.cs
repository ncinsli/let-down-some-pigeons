using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ConsentController : MonoBehaviour{
    //Если Consent = true, то игрок дал согласие на обработку данных -> можно записывать true в PlayerPrefs
    public void OnClick(bool consent){
        PlayerPrefs.SetInt("Consent", Convert.ToInt32(consent)); //PlayerPrefs не умеет в хранение boolean, поэтому нужны костыли
        transform.parent.gameObject.SetActive(false);
    }
}
