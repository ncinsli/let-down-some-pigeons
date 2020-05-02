using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRoundEnded : MonoBehaviour{
    
    public Pointer pointer;
    public GameObject stone;
    public GameObject player;

    [Header("Прочие зависимости")] //А также объекты кнопок :D
    public GameObject[] buttonsToDisable;
    public GameObject[] buttonsToEnable;
    public RoundInfoOutput[] titles; /*0 - заголовок, 1 - секунды, 2 - подпись к секундам*/
    public float pointTime = 5f; //Время на нацеливание

    private StoneScript stoneScript;
    private float axis;
    private RoundHandler roundHandler;
    private OnSelectedTarget onSelectedTarget;

    private void Start(){
        stoneScript = stone.GetComponent<StoneScript>();        
        roundHandler = GetComponent<RoundHandler>();
        onSelectedTarget = GetComponent<OnSelectedTarget>();
    }

    private void FixedUpdate(){
        if (roundHandler.roundTime < 0 && pointTime > 0){
            pointTime -= Time.deltaTime;   
            titles[0].SetText($"Стреляйте\n у вас {Mathf.Round(pointTime)} секунд"); 
        }
        if (pointTime < 0 && !stoneScript.didShoot){
            onSelectedTarget.ShowFailResult();
        }
    }

    public void DisableButtons(GameObject[] buttonsToDisable){
        foreach (GameObject obj in buttonsToDisable) obj.SetActive(false);
    }

    public void onRoundEnded(){
        
        stone.transform.position = player.transform.position + Vector3.right * (player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x));
        pointer.RenderBySpeed(pointer.speed);
        DisableButtons(buttonsToDisable);
        foreach (GameObject obj in buttonsToEnable) obj.SetActive(true);
        
        titles[1].SetText("Время истекло");
        titles[2].SetText(""); //Подпись к секундам уходит, когда время иссекает 

    }
    
}
