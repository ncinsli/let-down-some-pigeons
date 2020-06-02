using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlatformPhysEffect : MonoBehaviour{
    
    public float offset = 0.15f;
    public bool staysOnPlatform;

    private IEnumerator MoveDown(GameObject player){
        for (int i = 1; i < offset * 100f; i++){
            transform.position += Vector3.down * Mathf.Pow(Time.deltaTime, 1.7f);
            yield return new WaitForSeconds(0.01f);
        }
    }

    private IEnumerator MoveUp(GameObject player){  
        for (int i = 1; i < offset * 100f; i++){
            transform.position += Vector3.up * Mathf.Pow(Time.deltaTime, 1.7f);
            yield return new WaitForSeconds(0.01f);
        }
        staysOnPlatform = false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        staysOnPlatform = true;
        if (collision.gameObject.CompareTag("Player")) StartCoroutine(MoveDown(collision.gameObject));
    }

    private void OnCollisionExit2D(Collision2D collision){
        if (!staysOnPlatform && collision.gameObject.CompareTag("Player")) StartCoroutine(MoveUp(collision.gameObject));
    }
}
