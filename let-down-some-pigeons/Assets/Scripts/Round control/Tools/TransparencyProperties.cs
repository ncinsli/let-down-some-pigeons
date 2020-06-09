using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class TransparencyProperties : MonoBehaviour{
   
    public Text infoViewer;
    private Scrollbar scrollbar;

    private void Start(){
        scrollbar = GetComponent<Scrollbar>();
        scrollbar.value = PlayerPrefs.GetInt("MaskColorA") / 255.0f;
    }

    public void OnValueCustom() => infoViewer.text = Mathf.Round(scrollbar.value * 100f).ToString() + "%";
    private void OnDisable() {
        PlayerPrefs.SetInt("MaskColorA", Convert.ToInt32(scrollbar.value * 255));
        Debug.Log($"MASKCOLOR A IS {PlayerPrefs.GetInt("MaskColorA")}");
    }
}
