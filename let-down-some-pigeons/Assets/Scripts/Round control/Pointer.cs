using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Pointer : MonoBehaviour{

    public GameObject stone;
    public MoveObjects playerMover;
    public GameObject player;
    public Vector2 speed;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidbody;
    private Collider2D collider;
    private float axis;

    private void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();        
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();

        rigidbody.bodyType = RigidbodyType2D.Static;
        collider.enabled = false;
        spriteRenderer.enabled = false;

        if (speed == new Vector2(0f,0f))
            speed = new Vector2(370f,160f);
    }

    public void MoveX(int direction) =>
        transform.position += Vector3.right * direction * 0.1f;
        
    public void MoveY(int direction) =>
        transform.position += Vector3.up * direction * 0.1f;

    public void RenderBySpeed(Vector2 speed){
        if (playerMover.isFlying){
            transform.position = stone.transform.position * Vector2.right;
            stone.transform.position = stone.transform.position;
            stone.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 800f);
        }
        else transform.position = stone.transform.position;
        
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
        collider.enabled = true;
        rigidbody.AddForce(speed);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Stone")){
            rigidbody.bodyType = RigidbodyType2D.Static;
            collider.enabled = false;
            spriteRenderer.enabled = true;
        }
    }
}
