using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class BushScaling : MonoBehaviour{
    
    private IEnumerator MoveRightLeft(){
        for (int i = 0; i < 7; i++){
            transform.localScale += Vector3.left * 0.001f;
            transform.Rotate(0f, 0f, 0.25f);
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 7; i++){
            transform.localScale += Vector3.right * 0.001f;
            transform.Rotate(0f, 0f, -0.5f);
            yield return new WaitForSeconds(0.01f);
        }

        for (int i = 0; i < 7; i++){
            transform.localScale += Vector3.left * 0.001f;
            transform.Rotate(0f, 0f, 0.25f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")){
            StartCoroutine(MoveRightLeft());
        }
    }    
}
