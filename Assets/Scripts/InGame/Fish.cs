using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fish : MonoBehaviour
{
    public event Action<GameObject, GameObject> OnEndGame;

    [SerializeField] GameObject waterBall;
    [SerializeField] Sprite fishNormal;
    [SerializeField] Sprite fishFlapping;
    [SerializeField] GameObject enemy;

    GameObject shotWaterBall;
    GameManager gameManager;
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    Vector2 jumpVelocity;
    Vector2 shootVelocity;

    KeyCode keyBind;

    public float timer;
    float spawnOffset;
    int rotationY = 0;

    public float shootForce = 3;
    public float cooldown = 5;
    
   
    void Start()
    {
        timer = 0;
        jumpVelocity = new Vector2(0, 5);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (this.gameObject.name == "FishLeft")
        {
            keyBind = gameManager.keybindLeft;
            shootVelocity = new Vector2(1, 0);
            LeanTween.moveX(this.gameObject, -7, 1).setEaseOutCubic();
        }
        else
        {
            keyBind = gameManager.keybindRight;
            shootVelocity = new Vector2(-1, 0);
            LeanTween.moveX(this.gameObject, 7, 1).setEaseOutCubic();
            rotationY = 180;
        }
        spawnOffset = shootVelocity.x * 3 / 2;
        Invoke("ActivateRigidbody", 1);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= cooldown)
        {
            timer = cooldown;
        }
        if(Input.GetKeyDown(keyBind))
        {
            Jump();
        }
        if(transform.position.y < -5 || transform.position.y > 5)
        {
            OnEndGame.Invoke(enemy, this.gameObject);
        }
        transform.rotation = Quaternion.Euler(0, rotationY, rigidbody.velocity.y);
        if(Input.GetKeyUp(keyBind))
        {
            returnToNormalSprite();
        }
    }

    void Jump()
    {
        rigidbody.velocity = jumpVelocity;
        flappAnimation();
        if(timer >= cooldown)
        {
            Shoot();
            timer = 0;
        }
    }

    void Shoot()
    {
        shotWaterBall = Instantiate(waterBall, this.gameObject.transform.position + new Vector3(spawnOffset, 0, 0), Quaternion.Euler(0, 0, 0));
        if(gameObject.name == "FishRight")
        {
            shotWaterBall.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            shotWaterBall.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        shotWaterBall.GetComponent<Rigidbody2D>().velocity = shootVelocity * shootForce;
        shotWaterBall.GetComponent<WaterBall>().owner = this.gameObject.name;
    }

    private void ActivateRigidbody()
    {
        rigidbody.bodyType = RigidbodyType2D.Dynamic;
    }
    void flappAnimation()
    {
        spriteRenderer.sprite = fishFlapping;
    }

    void returnToNormalSprite()
    {
        spriteRenderer.sprite = fishNormal;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnEndGame.Invoke(enemy, this.gameObject);
    }
}
