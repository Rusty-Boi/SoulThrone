using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public float movementSpeed = 10f;
    [SerializeField] private Rigidbody2D rb;
    private float x, y;
    private Vector2 playerDirection;
    public Animator animator;
    private float currentSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    private void FixedUpdate()
    {
        Movement();
        Animate();
    }

    void PlayerInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(x, y).normalized;
        currentSpeed = rb.velocity.magnitude;
    }

    void Movement()
    {
        rb.velocity = new Vector2(playerDirection.x * movementSpeed, playerDirection.y * movementSpeed);
        
    }

    void Animate()
    {
        if(playerDirection != Vector2.zero)
        {
            animator.SetFloat("Horizontal", x);
            animator.SetFloat("Vertical", y);
        }
        animator.SetFloat("speed", currentSpeed);
    }
}
