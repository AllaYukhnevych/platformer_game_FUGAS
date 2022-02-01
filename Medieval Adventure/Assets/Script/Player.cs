using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour
{
    public bool _isGrounded;
    public float _maxSpeed;
    public float _normalSpeed = 0f;
    private bool _flipRight = true;
    private Animator animator;
    

    private void Start()
    {
        _maxSpeed= 0f;
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D()
    {
        _isGrounded = true;
    }

    
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(_maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        if (_maxSpeed != 0)
        {
            if (_maxSpeed > 0 && !_flipRight)
            {
                Flip();
            }
            if (_maxSpeed < 0 && _flipRight)
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

    public void OnLeftButtonDown()
    {
        if (_maxSpeed >= 0)
        {
            _maxSpeed = -_normalSpeed;
        }
    }

    public void OnRightButtonDown()
    {
        if (_maxSpeed <= 0)
        {
            _maxSpeed = _normalSpeed;
            
        }
    }
    public void OnJumpButtonDown()
    {
        _isGrounded = false;
        GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
    }
    public void OnButtonUp()
    {
        _maxSpeed = 0;
    }
    private void Flip()
    {
        _flipRight = !_flipRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
