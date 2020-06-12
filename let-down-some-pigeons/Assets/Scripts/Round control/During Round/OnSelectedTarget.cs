using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;

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
    private bool didShowResult = false;
    private const string API_KEY = "2b85497c65763a9ae8cea144f5e272625d0b5c1cdadb09b7";
    
    private void Start(){
        stoneScript = stone.GetComponent<StoneScript>();
        stoneSpriteRenderer = stone.GetComponent<SpriteRenderer>();
        stoneRigidbody = stone.GetComponent<Rigidbody2D>();
        roundEnd = GetComponent<OnRoundEnded>();
        stoneSpeed = pointer.speed;
    }

    public void ShowWinResult(){
        foreach (GameObject obj in resultGameObjectsOnWin) 
            if (obj != null) obj.SetActive(true);
    }

    private void ShowAd(){
        Debug.Log("Showing ad");
        Appodeal.show(Appodeal.INTERSTITIAL);
    }

    public void ShowFailResult(){
        Debug.Log($"Now fails are {PlayerPrefs.GetInt("Fails") + 1}");
        PlayerPrefs.SetInt("Fails", PlayerPrefs.GetInt("Fails") + 1);
        foreach (GameObject obj in resultGameObjectsOnFail)
            if (obj != null) obj.SetActive(true);
        if(PlayerPrefs.GetInt("Fails") % 3 == 0 ) Invoke("ShowAd", 0.3f);
    }

    private void FixedUpdate(){
        axis = player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x);
    }

    public void onSelectedTarget(){
        stoneScript = stone.GetComponent<StoneScript>();
        stoneSpriteRenderer = stone.GetComponent<SpriteRenderer>();
        stoneRigidbody = stone.GetComponent<Rigidbody2D>();
        
        stoneSpriteRenderer.enabled = true;
        stoneRigidbody.bodyType = RigidbodyType2D.Dynamic;
        stone.transform.position = player.transform.position + Vector3.right * 1.1f * axis;
        stoneScript.Shoot(pointer.transform.position - player.transform.position);
    }

    private void OnApplicationQuit(){
        PlayerPrefs.SetInt("Fails", 0);
    }
}
