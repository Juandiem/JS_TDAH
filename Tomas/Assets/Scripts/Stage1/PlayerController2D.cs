using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;
    public float offsetCamerY = 10.0f;
    public AnimatorController TimmyAnimatorStreet; 

    bool flip = true;
    float moveDirection = 0;
    bool isGrounded = false;
    public bool isStreet = false;
    bool animatorChange = true;

    Vector3 cameraPos;
    Rigidbody2D r2d;
    CapsuleCollider2D mainCollider;
    Transform t;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        t = transform;
        r2d = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        r2d.freezeRotation = true;
        r2d.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        r2d.gravityScale = gravityScale;
        flip = t.localScale.x < 0;
        animator = GetComponent<Animator>();

        if (mainCamera)
        {
            cameraPos = mainCamera.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Cambio de animaciones
        if (isStreet && animatorChange){
            animator.runtimeAnimatorController = TimmyAnimatorStreet as RuntimeAnimatorController;
            animatorChange = false;
        }

        // Movement controls
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
        }
        else
            moveDirection = 0;

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0)
                flip = true;
            if (moveDirection < 0)
                flip = false;

            GetComponent<SpriteRenderer>().flipX = flip;
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
        }

        // Camera follow
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(t.position.x, t.position.y+offsetCamerY, cameraPos.z);
        }

        //Gestion de animaciones
        if (Mathf.Abs(r2d.velocity.x) > 0.1f)
            animator.SetBool("Running", true);
        else
            animator.SetBool("Running", false);

        if(r2d.velocity.y > 0)
            animator.SetBool("Falling", false);
        else
            animator.SetBool("Falling", true);

        if (Mathf.Abs(r2d.velocity.y) < 0.1f && Mathf.Abs(r2d.velocity.y) > -0.1f)
            animator.SetBool("OnAir", false);
        else
            animator.SetBool("OnAir", true);


    }

    void FixedUpdate()
    {
        Bounds colliderBounds = mainCollider.bounds;
        float colliderRadius = mainCollider.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        //Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != mainCollider && !colliders[i].isTrigger)
                {
                    isGrounded = true;
                    break;
                }
            }
        }

        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
    }
}
