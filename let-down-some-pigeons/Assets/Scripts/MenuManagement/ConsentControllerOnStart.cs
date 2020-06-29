using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsentControllerOnStart : MonoBehaviour{
    private void Awake(){
        PlayerPrefs.SetInt("Consent", PlayerPrefs.GetInt("Consent") + 1);
        if (PlayerPrefs.GetInt("Consent") == 1) gameObject.SetActive(true);
        else gameObject.SetActive(false);
    }
}
