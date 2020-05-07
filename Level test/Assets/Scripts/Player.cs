using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    [SerializeField] private CameraRot cameraRot;
    [SerializeField] private float speed = 0.1f;

    /*0, 1, 2, 3, 4, 5 (left-right-forward-back-jump-interact)*/
    [SerializeField] private KeyCode[] keys; 
    
    private Rigidbody playerRigidbody;
    private Collider playerCollider;
    private Vector3 dist;


    private void Start(){
        playerCollider = GetComponent<Collider>();
        playerRigidbody = GetComponent<Rigidbody>();
        dist = cameraRot.distance.normalized;
    }

    private float CustomAxis(bool horizontalMode){
        if (horizontalMode){
            if (Input.GetKey(keys[0])) return -1f; //Must go left
            if (Input.GetKey(keys[1])) return 1f; //Must go right
            else return 0f; //Stays on place 
        }
        else{
            if (Input.GetKey(keys[2])) return 1f; //Must go forward
            if (Input.GetKey(keys[3])) return -1f; //Must go back
            else return 0f; //Stays on place 
        }
    } 

    private void FixedUpdate(){
        dist = cameraRot.distance.normalized;
        Debug.Log(dist);
        playerRigidbody.position += (CustomAxis(false)) * dist * speed;
    }
}
