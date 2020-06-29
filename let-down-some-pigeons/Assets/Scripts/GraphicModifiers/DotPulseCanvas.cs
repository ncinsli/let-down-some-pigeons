using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class DotPulseCanvas : MonoBehaviour {
    private float timeFromStart;
    [Range(0f, 0.1f)] public float scalingPower = 0f;
    [Range(0f, 100f)] public float movingPower = 1f;
    public bool moveRandomly = true;
    private Vector3 lastChoice;
    private int moveInterations;
    private RectTransform rectTransform;

    private void Start(){ 
        rectTransform = GetComponent<RectTransform>();
    }

    private void FixedUpdate(){
        timeFromStart += Time.deltaTime;
        rectTransform.localScale += new Vector3(1f, 1f, 0f) * Mathf.Sin(timeFromStart) * scalingPower; 
        if (moveRandomly){
            if (moveInterations % 48 == 0)
                lastChoice = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * movingPower;
            rectTransform.position += lastChoice;
            moveInterations += 1;
        }
    }
}