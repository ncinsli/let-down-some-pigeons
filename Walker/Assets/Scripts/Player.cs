using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public float speed = 0.05f; //Можно менять в редакторе

    private Collider2D playerCollider; //В юнити есть тип данных - Collider2D - по компоненту Collider2D. Это будет наш коллайдер игрока
    private Rigidbody2D playerRb; //Аналогично и с Rigidbody2D - физика
    private SpriteRenderer playerSpriteRenderer; //Аналогично с SpriteRenderer - отображатель текстур

    //Встроенная юнити функция, выполняется один раз, при старте игры
    private void Start(){
        playerCollider = GetComponent<Collider2D>(); //Наш коллайдер пустой, теперь присвоим ему коллайдер, лежащий на нашем игроке - GetComponent
        playerRb = GetComponent<Rigidbody2D>(); //GetComponent<ИмяКомпонента>(); берёт определенный компонент у объекта, к которому привязан скрипт    
        playerSpriteRenderer = GetComponent<SpriteRenderer>(); //Опять же, засовываем в пустой спрайтрендерер  спрайтрендерер нашего игрока
    }

    //Встроенная юнити функция, выполняется каждый кадр
    private void Update(){
        if (Input.GetKey(KeyCode.A)){ //При нажатии кнопки A (английской) на клавиатуре какое-то действие выполняется
            transform.position -= new Vector3(speed * 1f, 0f, 0f); //вычитаем из текущей позиции вектор скорость * 1, 0, 0
            playerSpriteRenderer.flipX = true; //Берём рендерер игрока, и ставим ему параметр flipX равным true
        }
        if (Input.GetKey(KeyCode.D)){
            transform.position += new Vector3(speed * 1f, 0f, 0f); //Прибавляем к текущей позиции вектор скорость * 1, 0, 0 
            playerSpriteRenderer.flipX = false; //Берём рендерер игрока, и ставим ему параметр flipX равным false
        }
    }
    //Таким образом каждый кадр игра будет проверять, нажал ли игрок A. Если да, то двигает влево. Нажал D? Если да, то двигает вправо

}
