using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
//[RequireComponent(typeof(Animator))]
public class PlayerAnimation : MonoBehaviour{
    
    private Animator playerAnimator;
    
    public MoveObjects objectMover; //MoveObjects компонент в геймконтроллере

    void Start(){
        playerAnimator = GetComponent<Animator>();
    }

    void FixedUpdate(){
        if (!objectMover.isMoving && !objectMover.isFlying)
            playerAnimator.SetInteger("AnimationId", 0);
        else if (!objectMover.isFlying) 
            playerAnimator.SetInteger("AnimationId", 1);
    }

    public void StartFlyingAnimation(){
        playerAnimator.SetInteger("AnimationId", 2);
    }
}
