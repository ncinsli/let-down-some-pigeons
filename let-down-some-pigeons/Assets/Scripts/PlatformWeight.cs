using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class PlatformWeight : MonoBehaviour{

    public float scale = 1f;
    public float axis = 1f;
    private IEnumerator GoByAxis(float axisY){
        for (int i = 1; i < 60; i++){
            transform.position += Vector3.down * 0.01f * 1/i * axisY/Mathf.Abs(axisY) * scale;
            yield return new WaitForSeconds(0.003f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.CompareTag("Player")) StartCoroutine(GoByAxis(axis));
    }

    private void OnTriggerExit2D(Collider2D collision){
       if (collision.gameObject.CompareTag("Player")) StartCoroutine(GoByAxis(-axis));
    }
}
