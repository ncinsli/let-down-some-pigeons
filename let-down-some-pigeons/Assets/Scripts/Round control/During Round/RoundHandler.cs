using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundHandler : MonoBehaviour{
    
    [HideInInspector] public string roundStatus = "Started"; //Строка, отвечающая за статус раунда
    [Range(1f, 100f)] public float roundTime = 20f; //Время, отведённое на раунд    

    [Header("Настройки и зависимости раунда")]
    public GameObject player;   
    public GameObject stone; //Наш камень
    public RoundInfoOutput timeTitle;
    public GameObject[] fastMenuElements;
    private float axis; //Показывает, куда повёрнут игрок;
    private MoveObjects movingController; //Для принудительной остановки персонажа
    private Rigidbody2D playerRigidbody;
    private OnRoundEnded roundEnd; 

    private void Start(){ //По умолчанию раунд стартуется в начале загрузки сцены
        roundEnd = GetComponent<OnRoundEnded>();
        movingController = GetComponent<MoveObjects>();
        playerRigidbody = player.GetComponent<Rigidbody2D>();  
    }

    private void FixedUpdate(){
        axis = player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x);

        if (roundTime > 0f){
            timeTitle.SetText("          " + Mathf.Round(roundTime).ToString()); 
            roundTime -= Time.deltaTime;
        }
        
        if (roundTime < 0 && roundStatus != "Finished"){
            PlayerPrefs.SetString(roundStatus,"Finished");
            roundStatus = "Finished";
            roundEnd.onRoundEnded();
        }
    }

    public void FastMenuOpen(){
        foreach(GameObject obj in fastMenuElements) if (obj != null) obj.SetActive(true);
        Time.timeScale = 0f;
    }
    public void FastMenuClose(){ 
        foreach(GameObject obj in fastMenuElements) if (obj != null) obj.SetActive(false);
        Time.timeScale = 1f;
    }
    
}
