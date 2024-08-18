using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator playerAnime;
    private SpriteRenderer SR;
    private Rigidbody2D rbPlayer;
    private Transform playerTransform;
    public float SPD = 2.5f;
    public float fcJump = 200;
    private bool Infloar = true;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
        SR = GetComponent<SpriteRenderer>();
        playerAnime = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        MovePlayer();
    }
    void Update()
    {
        Jump();
    }
    void MovePlayer()
    {
        float horizontalMoviment = Input.GetAxisRaw("Horizontal");
        rbPlayer.constraints = RigidbodyConstraints2D.FreezeRotation;
        rbPlayer.linearVelocity = new Vector2(horizontalMoviment * SPD, rbPlayer.linearVelocity.y);
        Debug.Log(horizontalMoviment);
        if (horizontalMoviment > 0)
        {
            playerAnime.SetBool("isWalking", true);
            SR.flipX = false;
        }
        else if (horizontalMoviment < 0)
        {
            playerAnime.SetBool("isWalking", true);
            SR.flipX = true;
        }
        else
        {
            playerAnime.SetBool("isWalking", false);
        }
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && Infloar)
        {
            rbPlayer.AddForce(new Vector2(0, fcJump), ForceMode2D.Impulse);
            Infloar = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            Infloar = true;
        }
    }
}
