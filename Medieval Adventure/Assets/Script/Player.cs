using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    public bool _isGrounded;
    public float _maxSpeed=10f;
    public float _normalSpeed = 0f;
    public static bool _flipRight = true;
    private Animator animator;
    public GameObject pauseMenuUI;
    private Vector3 respawnPoint;
    public GameObject fallDetector;

    private void Start()
    {
        _maxSpeed= 0f;
        respawnPoint = transform.position;
        animator = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D()
    {
        _isGrounded = true;
    }

    
    void Update()
    {
        //float move = Input.GetAxis("Horizontal");
        //GetComponent<Rigidbody2D>().velocity = new Vector2(move * _maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

        //if (Input.GetKeyUp(KeyCode.Space) && _isGrounded)
        //{
        //    _isGrounded = false;
        //    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
        //}

        //if (Input.GetAxis("Horizontal") != 0)
        //{
        //    if (move > 0 && !_flipRight)
        //    {
        //        Flip();
        //    }
        //    if (move < 0 && _flipRight)
        //    {
        //        Flip();
        //    };
        //    animator.SetInteger("State", 1);
        //}
        //else
        //{
        //    animator.SetInteger("State", 0);
        //}

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

        fallDetector.transform.position = new Vector2(transform.position.x, fallDetector.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FallDetector")
        {
            transform.position = respawnPoint;
            Life.health -= 1;
        }
        else if (collision.tag == "CheackPoint")
        {
            respawnPoint = transform.position;
        }
        if (Life.health == 0)
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
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
    public void Flip()
    {
        _flipRight = !_flipRight;
        Vector2 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
   
}
