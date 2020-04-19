using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Этот скрипт - GameController компонент
public class MoveObjects : MonoBehaviour{
    
    public int currentAxis = 1; //Будет обозначать то, какую кнопку нажали сейчас
    public bool doFlip = true; //Если да, то в зависимости от движения, объект, который будет двигаться, будет ещё и отражаться
    public float speed {get; set;}
    public float jumpPower {get; set;}

    public GameObject selectedObject;
    public bool isMoving {get; set;}
    public bool isFlying {get; set;}
    
    public void MoveByAxis(int axis){
        Rigidbody2D objectRigidbody = selectedObject.GetComponent<Rigidbody2D>();
        objectRigidbody.position += Vector2.right * speed * axis;
        currentAxis = axis;
    }

    public void MoveUp(){
        Rigidbody2D objectRigidbody = selectedObject.GetComponent<Rigidbody2D>();
        objectRigidbody.position += Vector2.up * jumpPower * 20f;
    }

    private void FixedUpdate(){
        if (isMoving)
            MoveByAxis(currentAxis);

        if (doFlip){
            Transform sTransform = selectedObject.transform;
            sTransform.localScale = new Vector2(Mathf.Abs(sTransform.localScale.x) * currentAxis, sTransform.localScale.y);
        }

        if (isFlying)
            MoveUp();
    }
}
