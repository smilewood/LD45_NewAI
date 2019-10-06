
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public bool canMoveLeft, canMoveRight, canJump;
    private GameObject respawnPoint;
    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        if (stopMovment)
        {
            animator.SetBool("Moving", false);
            return;
        }
        move.x = Input.GetAxis("Horizontal");
        move.x = Mathf.Clamp(move.x, (canMoveLeft ? float.MinValue : 0f), (canMoveRight ? float.MaxValue : 0f));

        if (Input.GetButtonDown("Jump") && grounded && canJump)
        {
            animator.SetTrigger("Jump");
            StartCoroutine(Jump());
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }

        bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.05f) : (move.x < -0.05f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
        animator.SetBool("Moving", (move.x != 0f));
        animator.SetBool("Grounded", grounded);

        targetVelocity = move * maxSpeed;
    }

    IEnumerator Jump()
    {
        GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(.07f);

        if (grounded)
        {
            velocity.y = jumpTakeOffSpeed;


        }
    }
    private void OnTriggerEnter2D( Collider2D other )
    {
        if (other.gameObject.tag.Equals("EnviromentalDeath"))
        {
            this.transform.position = respawnPoint.transform.position;
        }
        if (other.gameObject.tag.Equals("RespawnPoint"))
        {
            this.respawnPoint = other.gameObject;
        }
    }

    public static bool stopMovment = false;

}