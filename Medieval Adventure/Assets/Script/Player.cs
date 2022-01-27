using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool _isGrounded;
    public float _maxSpeed = 10f;
    private bool _flipRight = true;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D()
    {
        _isGrounded = true;
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(move * _maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetKeyUp(KeyCode.Space) && _isGrounded)
        {
            _isGrounded = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
        }

        if (Input.GetAxis("Horizontal") != 0)
        {
            if (move > 0 && !_flipRight)
            {
                Flip();
            }
            if (move < 0 && _flipRight)
            {
                Flip();
            };
            animator.SetInteger("State", 1);
        }
        else
        {
            animator.SetInteger("State", 0);
        }
    }

    private void Flip()
    {
        _flipRight = !_flipRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
