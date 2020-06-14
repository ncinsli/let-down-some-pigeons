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
    private Transform camera;

    [Range(0,5f)] public float delayTime = 1.1f;
    public GameObject shootButton;
    public OnRoundEnded roundEndController;
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
        rigidbody.AddForce(force * 2400f * Mathf.Pow(Time.deltaTime,1f) * (player.localScale.x / Mathf.Abs(player.localScale.x)));
        rigidbody.gravityScale = Time.deltaTime * 2f;
        Debug.Log(force);
        didShoot = true;
        Time.timeScale = 1f;
        roundEndController.DisableButtons(new GameObject[] {shootButton});
    }

    private void FixedUpdate(){
        axis = player.localScale.x / Mathf.Abs(player.localScale.x);
        if (didShoot && !didShowWindow){
            objectFollower.zCamCoord = -7f; //-10 - стандартная, 0- вплотную

            objectFollower.targetTransform = transform;
        }
    }

    private void ShowWinResultAdapter(){ 
        Debug.Log("Starting function ShowWinResultAdapter...");
        resultShower.ShowWinResult();
        Destroy(gameObject);
    }

    private void CollisionHandler(Collision2D collision){
        Time.timeScale = 1f;
        if(didShoot && !didShowWindow){
            if (collision.gameObject.CompareTag("Enemy")){
                var enemyAnimator = collision.gameObject.GetComponent<Animator>();
                spriteRenderer.enabled = false;
                gotToEnemy = true;
                pointer.GetComponent<SpriteRenderer>().enabled = false;
                objectFollower.targetTransform = collision.gameObject.transform;

                enemyAnimator.SetInteger("AnimationId", 1);
                Invoke("ShowWinResultAdapter", delayTime);
            }
            else if (!collision.gameObject.CompareTag("Player")){
                objectFollower.targetTransform = collision.gameObject.transform;
                resultShower.ShowFailResult();
                Destroy(gameObject);
            }
            didShoot = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) => CollisionHandler(collision);
    private void OnCollisionStay2D(Collision2D collision) => CollisionHandler(collision);
}
