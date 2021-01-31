using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{

    //Configuraciones
    public float speed = 2.5f;
    public float jumpForce = 7.5f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;
    public float fallSpeed;

    //Componentes
    private Rigidbody2D _rigidbody;

    //Auxiliares
    private Vector2 _movement;
    private bool _isGrounded;
    private bool _isFalling;
    //[HideInInspector]
    public bool isSniffing;

    // Start is called before the first frame update
    void Start()
    {
        _isFalling = false;
        isSniffing = false;
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSniffing || (GameSystem.instance != null && GameSystem.instance.isPaused()))
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }

        Movement();
    }

    void FixedUpdate()
    {
        if (isSniffing || (GameSystem.instance != null && GameSystem.instance.isPaused()))
        {
            _rigidbody.velocity = Vector2.zero;
            return;
        }

        float horizontalVelocity = _movement.normalized.x * speed;
        _rigidbody.velocity = new Vector2(horizontalVelocity, _rigidbody.velocity.y);
    }

    private void Movement()
    {
        //Horizontal
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        _movement = new Vector2(horizontalInput, 0f);

        //Vertical
        _isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (_isGrounded)
        {
            _isFalling = false;
        }

        if (Input.GetButtonDown("Jump") && _isGrounded == true && _rigidbody.velocity.y == 0f)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        if (!_isGrounded && _rigidbody.velocity.y < 0f && !_isFalling) 
        {
            _isFalling = true;
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * fallSpeed);
        }
    }

    public Vector2 GetSpeed()
    {
        return _rigidbody.velocity;
    }

    public bool IsGrounded()
    {
        return _isGrounded;
    }

}
