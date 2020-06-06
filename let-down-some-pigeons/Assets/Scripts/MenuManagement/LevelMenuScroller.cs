using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Scrollbar))]
public class LevelMenuScroller : MonoBehaviour{
    public RectTransform content;
    private float xStart;
    private Scrollbar scrollbar;

    private void Start(){
        xStart = content.anchoredPosition.x;
        scrollbar = GetComponent<Scrollbar>();
    }

}
