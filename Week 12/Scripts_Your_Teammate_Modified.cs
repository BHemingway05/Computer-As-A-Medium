//GameManager.cs
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject player;
    public GameObject gameOverUI;

    public GameObject PlayAgainUI;

    private bool isGameOver = false;
    // Start is called once before the first execution of Update after MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        GameEnd();
    }
    void GameEnd()
    {
        if (playerHealth.health <= 0 && !isGameOver)
        {
            isGameOver = true;
            StartCoroutine(BeforeEnd());
            IEnumerator VictoryMessage()
            {
                Debug.Log("You entered a special area!");

                yield return new WaitForSeconds(3f);

                Debug.Log("Bonus unlocked!");
            }
        }

    }
        IEnumerator BeforeEnd()
        {

            playerHealth.healthText.text = "Health: ";
            player.SetActive(false);
            PlayAgainUI.SetActive(true);
            yield return new WaitForSeconds(3f);
            PlayAgainUI.SetActive(false);
            gameOverUI.SetActive(true);
        }


        



    
}

//PlayerMovement.cs
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public Transform sword;
    private float speedX = 0f;
    private float speedY = 0f;
    public Rigidbody2D rb;

    public SpriteRenderer spriteRenderer;

    public Sprite beartop;
    public Sprite beardown;
    public Sprite bearright;
    public Sprite bearleft;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    void Movement()
    {
        // Horizontal Movement
        if (Keyboard.current.aKey.isPressed)
        {
            speedX = -moveSpeed;
            spriteRenderer.sprite = bearleft;

            sword.localPosition = new Vector3(-0.5f, 0f, 0f);
            sword.localRotation = Quaternion.Euler(0, 0, 180);
        }
        else if (Keyboard.current.dKey.isPressed)
        {
            speedX = moveSpeed;
            spriteRenderer.sprite = bearright;

            sword.localPosition = new Vector3(0.5f, 0f, 0f);
            sword.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            speedX = 0;
        }

        // Vertical Movement
        if (Keyboard.current.wKey.isPressed)
        {
            speedY = moveSpeed;
            spriteRenderer.sprite = beartop;

            sword.localPosition = new Vector3(0f, 0.5f, 0f);
            sword.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            speedY = -moveSpeed;
            spriteRenderer.sprite = beardown;

            sword.localPosition = new Vector3(0f, -0.5f, 0f);
            sword.localRotation = Quaternion.Euler(0, 0, -90);
        }
        else
        {
            speedY = 0;
        }

        rb.linearVelocity = new Vector2(speedX, speedY);
    }
}

//PlayerAttack.cs
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerAttack : MonoBehaviour
{
    public Animator animator;
    public GameObject bulletPrefab;
    public Transform firePoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    void Attack()
    {
        if (Keyboard.current.fKey.isPressed)
        {
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }

    void Shoot()
    {
        if (Keyboard.current.fKey.wasPressedThisFrame)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

    }

}