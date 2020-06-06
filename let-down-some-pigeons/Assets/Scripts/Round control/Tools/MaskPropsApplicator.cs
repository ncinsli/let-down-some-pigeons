using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaskPropsApplicator : MonoBehaviour{
    public MaskProperties maskPropertiesFile;
    private SpriteRenderer spriteRenderer;
    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = maskPropertiesFile.MaskColor;
        transform.localScale = maskPropertiesFile.Scale;
    }
}
