using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class MaskPropertiesApplicator : MonoBehaviour{
    
    private SpriteRenderer spriteRenderer;

    private void Start(){
        transform.localScale = new Vector2(18f, 10f);
        spriteRenderer = GetComponent<SpriteRenderer>();
        float r = PlayerPrefs.GetInt("MaskColorR") / 255.0f;
        float a = PlayerPrefs.GetInt("MaskColorA") / 255.0f;
        spriteRenderer.color = new Color(r,r,r,a);
    }


}
