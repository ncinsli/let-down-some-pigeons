using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spike : MonoBehaviour{
    public Animator playerAnimator;
    public OnSelectedTarget resultShower;
    public Animator enemyAnimator;
  
    private void ShowWinResultAdapter(){ 
        Debug.Log("Starting function ShowWinResultAdapter...");
        resultShower.ShowWinResult();
        Destroy(gameObject);
    }
    //Знаю, это говнокод, но так очень просто делать задержку, ведь Invoke() не поддерживает методы, только строки
    //К чёрту корутины в таких простых вещах!
    private void ShowFailResultAdapter(){
        Debug.Log("Starting function ShowFailResultAdapter...");
        resultShower.ShowFailResult();
    }


    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.CompareTag("Player")){
          playerAnimator.SetInteger("AnimationId", 3);
          Invoke("ShowFailResultAdapter", 0.3f);
        }
        if (collision.gameObject.CompareTag("Enemy")){
          enemyAnimator.SetInteger("AnimationId", 1); //Анимация смерти
          Invoke("ShowWinResultAdapter", 1.1f);
        }
        
    }
}
