using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : MonoBehaviour{

    public float breathingScaler = 4f;
    private float timeFromStart;

    private void Start() => timeFromStart = Random.Range(-1f, 1f);

    private void FixedUpdate(){
        timeFromStart += Time.deltaTime;
        transform.position += Vector3.up * 0.0025f * Mathf.Sin(timeFromStart);
        transform.localScale += Vector3.right * Mathf.Pow(0.1f, breathingScaler) * Mathf.Sin(timeFromStart);
    }
}
