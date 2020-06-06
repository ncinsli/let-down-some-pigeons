using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class TransparencyController : MonoBehaviour{

    public Text infoViewer;
    public MaskProperties maskProperties;
    private Scrollbar scrollbar;

    private void Start(){
        scrollbar = GetComponent<Scrollbar>();
        scrollbar.value = maskProperties.MaskColor.a; //.0 ещё раз сообщает шарпу, что делить надо дробно. Иначе не работает
        infoViewer.text = (Mathf.Round(scrollbar.value * 100f) * 0.01f).ToString();
    }

    public void OnValueChangedCustom(){
        byte r = Convert.ToByte(maskProperties.MaskColor.r * 255f);
        byte g = Convert.ToByte(maskProperties.MaskColor.g * 255f);
        byte b = Convert.ToByte(maskProperties.MaskColor.b * 255f);
        maskProperties.MaskColor = new Color32(r, g, b, Convert.ToByte(scrollbar.value * 255f));
        infoViewer.text = (Mathf.Round(scrollbar.value * 100f) * 0.01f).ToString();
    }
}