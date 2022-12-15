using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    // Move player in 2D space
    public float maxSpeed = 3.4f;
    public float jumpHeight = 6.5f;
    public float gravityScale = 1.5f;
    public Camera mainCamera;
    public float offsetCamerY = 10.0f;
    public Animator TimmyAnimatorStreet;
    public bool allowMove { get;  set; }

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
        allowMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Cambio de animaciones
        if (isStreet && animatorChange){
            animator.runtimeAnimatorController = TimmyAnimatorStreet.runtimeAnimatorController;
            animatorChange = false;
        }

        if (allowMove && !GameManager.instance.isOnDialogue)
        {

            // Movement controls
            if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
            {
                moveDirection = Input.GetKey(KeyCode.A) ? -1 : 1;
            }
            else
                moveDirection = 0;

            // Jumping
            if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            {
                r2d.velocity = new Vector2(r2d.velocity.x, jumpHeight);
            }
        }

        // Change facing direction
        if (moveDirection != 0)
        {
            if (moveDirection > 0)
                flip = true;
            if (moveDirection < 0)
                flip = false;

            GetComponent<SpriteRenderer>().flipX = flip;
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

        if (isGrounded)
            animator.SetBool("OnAir", false);
        else
            animator.SetBool("OnAir", true);


    }

    void FixedUpdate()
    {
        // Apply movement velocity
        r2d.velocity = new Vector2((moveDirection) * maxSpeed, r2d.velocity.y);
    }

    public void changeStreet()
    {
        isStreet = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Floor") isGrounded = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Floor") isGrounded = false;
    }
}
