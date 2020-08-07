using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Animator anim;
    Vector3 movePos;
    public float jumpForce = 10f;
    bool isJumping = false;

    private Rigidbody2D rb;

    public AudioClip jumpClip;
    public AudioSource audioSource;

    void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        if (PlayerPrefs.HasKey("SFX_Volume")) {
            audioSource.volume = PlayerPrefs.GetFloat("SFX_Volume");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float movement = Input.GetAxisRaw("Horizontal");
        if (movement > 0f) {
            Vector3 temp = transform.localScale;
            temp.x = Math.Abs(temp.x);
            transform.localScale = temp;

            rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
            anim.SetBool("IsWalking", true);
        } else if (movement < 0f) {
            Vector3 temp = transform.localScale;
            temp.x = Math.Abs(temp.x) * -1;
            transform.localScale = temp;

            rb.velocity = new Vector2(movement * moveSpeed, rb.velocity.y);
            anim.SetBool("IsWalking", true);
        } else {
            rb.velocity = new Vector2(0, rb.velocity.y);
            anim.SetBool("IsWalking", false);
        }

        //JUMPING
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0)) && !isJumping) {
            audioSource.PlayOneShot(jumpClip);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isJumping = true;
        }
    }

    private void FixedUpdate() {
       
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") {
            isJumping = false;
        }

        /*if (collision.gameObject.tag == "playTape") {
            GameObject playTape = collision.gameObject;

            Debug.Log("player gets tape");
            GameManager.Instance.SetPlayTapeCount(GameManager.Instance.GetPlayTapeCount() + 1);
            Destroy(playTape);
        }*/
    }
}
