using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class LightProperties : MonoBehaviour{

    public Text infoViewer;
    private Scrollbar scrollbar;

    private void Start(){
        scrollbar = GetComponent<Scrollbar>();    
        scrollbar.value = PlayerPrefs.GetInt("MaskColorR") / 255.0f;
    }

    public void OnValueCustom() => infoViewer.text = Mathf.Round(scrollbar.value * 100f).ToString() + "%";
    private void OnDisable() {
        PlayerPrefs.SetInt("MaskColorR", Convert.ToInt32(scrollbar.value * 255f));
        Debug.Log($"MASKCOLOR R IS {PlayerPrefs.GetInt("MaskColorR")}");
    }
}
