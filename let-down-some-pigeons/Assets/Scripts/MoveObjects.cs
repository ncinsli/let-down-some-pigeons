using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
//Этот скрипт - GameController компонент
public class MoveObjects : MonoBehaviour{
    
    public int currentAxis = 1; //Будет обозначать то, какую кнопку нажали сейчас
    public bool doFlip = true; //Если да, то в зависимости от движения, объект, который будет двигаться, будет ещё и отражаться
    public float speed {get; set;}
    public float jumpPower {get; set;}

    public GameObject selectedObject;
    public bool isMoving {get; set;}
    public bool isFlying {get; set;}
    
    private Button sender; //Кнопка, которая отправила действие. Нужно для отключения прыжка
    private EventTrigger senderEventTrigger; //Чтобы изменения были и в поведении кнопок
    private int jumpCount = 0;

    public void MoveByAxis(int axis){
        Rigidbody2D objectRigidbody = selectedObject.GetComponent<Rigidbody2D>();
        objectRigidbody.position += Vector2.right * speed * axis;
        currentAxis = axis;
    }

    public void MoveUp(GameObject s){
        /*sender = s.GetComponent<Button>();
        senderEventTrigger = s.GetComponent<EventTrigger>();
        jumpCount++;*/
        Rigidbody2D objectRigidbody = selectedObject.GetComponent<Rigidbody2D>();
        objectRigidbody.position += Vector2.up * jumpPower * 0.13f;
        /*if (jumpCount % 2 == 0){
            sender.interactable = false;
            senderEventTrigger.enabled = false;
            Invoke("ActivateJumpButton",0.7f);
        }*/
        //if (!isFlying) objectRigidbody.position += Vector2.down * jumpPower;
    }

    /*private void ActivateJumpButton(){ 
        sender.interactable = true;
        senderEventTrigger.enabled = true;
    }*/
    private void FixedUpdate(){
        if (isMoving)
            MoveByAxis(currentAxis);
        if (isFlying)
            MoveUp(gameObject);
        if (doFlip){
            Transform sTransform = selectedObject.transform;
            sTransform.localScale = new Vector2(Mathf.Abs(sTransform.localScale.x) * currentAxis, sTransform.localScale.y);
        }
    }
}
