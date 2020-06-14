using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DotPulse : MonoBehaviour {
    private float timeFromStart;
    [Range(0f, 1f)] public float scalingPower = 1f;
    [Range(0f, 1f)] public float movingPower = 1f;
    public bool moveRandomly;

    private void FixedUpdate(){
        timeFromStart += Time.deltaTime;
        transform.localScale += new Vector3(1f, 1f, 0f) * Mathf.Sin(timeFromStart) * scalingPower; 
        if (moveRandomly) transform.position += new Vector3(1f, 1f, 0f) * Random.Range(0f, 1f) * movingPower;
    }
}