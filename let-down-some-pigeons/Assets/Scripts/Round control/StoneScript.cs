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
    private float magnitudeOnStart;
    private Transform camera;

    public FollowObjects objectFollower;
    public Transform player;
    public Transform enemy;
    public bool didShoot = false;
    public GameObject pointer;
    public OnSelectedTarget resultShower; //Этот скрипт отвечает за показ результата
    public bool gotToEnemy = false; 

    private void Start(){
        rigidbody = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        camera = Camera.main.transform;
        spriteRenderer.enabled = false;
        rigidbody.bodyType = RigidbodyType2D.Static;
        axis = player.localScale.x / Mathf.Abs(player.localScale.x);
    }

    public void Shoot(Vector2 force){
        rigidbody.AddForce(force * 170f * (player.localScale.x / Mathf.Abs(player.localScale.x)));
        Debug.Log(force);
        didShoot = true;
        objectFollower.enabled = false;
        Time.timeScale = 1f;
        magnitudeOnStart = (enemy.position - transform.position).magnitude;
    }

    private void FixedUpdate(){
        axis = player.localScale.x / Mathf.Abs(player.localScale.x);
        if (didShoot && !didShowWindow){
            Debug.Log(1f/Time.fixedDeltaTime);
            Vector2 direction = enemy.position - transform.position;
            Debug.DrawRay(transform.position, direction);
            float currentZ = Mathf.Lerp(-10f, -6f, 1f-direction.magnitude/magnitudeOnStart);
            camera.transform.position = new Vector3(transform.position.x, transform.position.y, currentZ);
        }
    }


    private void CollisionHandler(Collision2D collision){
        Time.timeScale = 1f;
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
