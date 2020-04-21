using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour{
    
    public GameObject[] groundObjects; //Объекты земли
    public GameObject enemyObject;
    public float startpointX = -22.3f;
    public float finishPointX = 22.3f;

    public float platformWidth;
    public float yStart = -4.7f;

    private void Start(){
        platformWidth = groundObjects[0].transform.localScale.x * 5f;
        //Первый проход
        for (float i = startpointX; i < finishPointX; i += platformWidth){
            var currentObj = Instantiate(groundObjects[Random.Range(0,groundObjects.Length - 1)]);
            currentObj.transform.position = new Vector2(i,yStart-1.89f);
        }    
        //Второй уровень
        for (float i = startpointX; i < finishPointX; i += platformWidth){
            if (Random.Range(0,5) == 3){
                var currentObj = Instantiate(groundObjects[2]);
                currentObj.transform.position = new Vector2(i,yStart-1f);
                if (Random.Range(1,3) == 2){
                    var currentObj2 = Instantiate(groundObjects[Random.Range(0,2)]);
                    currentObj2.transform.position = new Vector2(i + Random.Range(-1f,1f),yStart+0.6f);
                }
            }
        }    
    }

    private void Update(){
        
    }
}
