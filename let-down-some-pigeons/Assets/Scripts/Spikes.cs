using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour{
    public Animator playerAnimator;
    public Animator enemyAnimator;

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
            playerAnimator.SetInteger("AnimationId", 3); //Анимация смерти
        }
        if (collision.gameObject.CompareTag("Enemy")){
            enemyAnimator.SetInteger("AnimationId", 1);
        }
        
    }
}
