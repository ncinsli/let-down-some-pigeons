using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MaskPropertiesApplicator : MonoBehaviour{

    public bool isBgMask;    
    private SpriteRenderer spriteRenderer;

    private void Start(){
        transform.localScale = new Vector2(25f, 15f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        float r = PlayerPrefs.GetInt("MaskColorR") / 255.0f;
        float a = PlayerPrefs.GetInt("MaskColorA") / 255.0f;
        if (isBgMask && r < 185f) r += 70f;
        if (isBgMask && r > 185f) r = 205f;
        spriteRenderer.color = new Color(r,r,r,a);
    }


}
