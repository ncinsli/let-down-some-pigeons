using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSelectedTarget : MonoBehaviour{
    
    public GameObject stone;
    public GameObject player;
    public Pointer pointer;
    public GameObject[] resultGameObjectsOnWin; //Объекты, которые будут включаться в момент вывода "Победа"
    public GameObject[] resultGameObjectsOnFail; //При выводе "Поражение"

    private OnRoundEnded roundEnd; //Для обработки пары событий
    private Vector2 stoneSpeed;
    private StoneScript stoneScript;
    private SpriteRenderer stoneSpriteRenderer;
    private Rigidbody2D stoneRigidbody;

    private float axis;
    private float pointTime;

    private void Start(){
        stoneScript = stone.GetComponent<StoneScript>();
        stoneSpriteRenderer = stone.GetComponent<SpriteRenderer>();
        stoneRigidbody = stone.GetComponent<Rigidbody2D>();
        roundEnd = GetComponent<OnRoundEnded>();

        stoneSpeed = pointer.speed;
    }

    public void ShowWinResult(){
        foreach (GameObject obj in resultGameObjectsOnWin) obj.SetActive(true);
    }

    public void ShowFailResult(){
        foreach (GameObject obj in resultGameObjectsOnFail) obj.SetActive(true);
    }

    private void FixedUpdate(){
        axis = player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x);
    }

    public void onSelectedTarget(){
        stoneSpriteRenderer.enabled = true;
        stoneRigidbody.bodyType = RigidbodyType2D.Dynamic;
        stone.transform.position = player.transform.position + Vector3.right *1.1f* axis;
        stoneScript.Shoot(pointer.transform.position - player.transform.position);
    }
}
