using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class LightController : MonoBehaviour{

    public Text infoViewer;
    public MaskProperties maskProperties;
    private Scrollbar scrollbar;

    private void Start(){
        scrollbar = GetComponent<Scrollbar>();
        scrollbar.value = maskProperties.MaskColor.r;
        infoViewer.text = (Mathf.Round(scrollbar.value * 100f) * 0.01f).ToString();
    }

    public void OnValueChangedCustom(){
        byte value = Convert.ToByte(scrollbar.value * 255);
        maskProperties.MaskColor = new Color32(value, value, value, Convert.ToByte(maskProperties.MaskColor.a * 255f));
        infoViewer.text = (Mathf.Round(scrollbar.value * 100f) * 0.01f).ToString();
    }
}
