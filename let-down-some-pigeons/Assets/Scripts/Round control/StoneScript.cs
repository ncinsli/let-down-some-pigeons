using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class StoneScript : MonoBehaviour{ 

    private Rigidbody2D rigidbody;
    private Collider2D collider;
    private SpriteRenderer spriteRenderer;
    private float axis;
    private bool didShowWindow = false;

    public Transform player;
    public bool didShoot = false;
    public GameObject pointer;
    public OnSelectedTarget resultShower; //Этот скрипт отвечает за показ результата
    public bool gotToEnemy = false; 

    private void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        spriteRenderer.enabled = false;
        rigidbody.bodyType = RigidbodyType2D.Static;
        axis = player.localScale.x / Mathf.Abs(player.localScale.x);
    }

    public void Shoot(Vector2 force){
        rigidbody.AddForce(force * 170f * (player.localScale.x / Mathf.Abs(player.localScale.x)));
        Debug.Log(force);
        didShoot = true;
    }

    private void CollisionHandler(Collision2D collision){
        if(didShoot && !didShowWindow){
            if (collision.gameObject.CompareTag("Enemy")){
                Destroy(collision.gameObject);
                resultShower.ShowWinResult();
                gotToEnemy = true;
            }
            else if (!collision.gameObject.CompareTag("Player")){
                resultShower.ShowFailResult();
            }
            didShoot = true;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) => CollisionHandler(collision);
    private void OnCollisionStay2D(Collision2D collision) => CollisionHandler(collision);
}
