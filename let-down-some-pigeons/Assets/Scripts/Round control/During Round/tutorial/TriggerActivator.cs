using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TriggerActivator : MonoBehaviour{
    public SpriteRenderer[] textsRenderer;
    public OnRoundEnded onRoundEnded;

    private void Start(){
       foreach (var obj in textsRenderer) obj.enabled = false; 
    }

    private void OnTriggerEnter2D(Collider2D col){
        foreach (var obj in textsRenderer) obj.enabled = true; 
        onRoundEnded.pointTime = int.MaxValue;
        onRoundEnded.onRoundEnded();
        Destroy(gameObject);
    }
}
