using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DotPulse : MonoBehaviour {
    private float timeFromStart;
    [Range(0f, 0.1f)] public float scalingPower = 0f;
    [Range(0f, 0.1f)] public float movingPower = 0.0055f;
    public bool unlockMoving = false;
    public bool moveRandomly = true;
    public bool useY = true;
    public int iterationsMax = 37;
    private Vector3 lastChoice;
    private int moveInterations;

    private void Start(){ 
        if (!unlockMoving) movingPower = 0.0055f;
    }
    private void FixedUpdate(){
        timeFromStart += Time.deltaTime;
        transform.localScale += new Vector3(1f, 1f, 0f) * Mathf.Sin(timeFromStart) * scalingPower; 
        if (moveRandomly){
            if (moveInterations % iterationsMax == 0)
                lastChoice = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f) * movingPower;
            if (!useY) lastChoice.y = 0f;
            transform.position += lastChoice;
            moveInterations += 1;
        }
    }
}