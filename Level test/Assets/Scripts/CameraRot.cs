using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRot : MonoBehaviour{

    [SerializeField] private float sensitivity = 0.5f;

    private Camera camera;
    public Transform target;
    public Vector3 distance;

    private void Start(){
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        camera = GetComponent<Camera>();
        
    }

    private void FixedUpdate(){
        var angleByX = Input.mousePosition.x*0.4f-((Screen.width/2f)/Screen.width);
        transform.rotation = Quaternion.Euler(transform.rotation.x, sensitivity * angleByX, transform.rotation.z);
        distance = target.transform.position - transform.position;
    }
}
