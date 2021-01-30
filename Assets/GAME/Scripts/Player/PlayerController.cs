﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Configuraciones
    public float speed = 2.5f;
    public float jumpForce = 7.5f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;

    private RastroController _rastro;
    
    //Componentes
    private Rigidbody2D _rigidbody;

    //Auxiliares
    private Vector2 _movement;
    private bool _isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rastro = GetComponentInChildren<RastroController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void FixedUpdate()
    {
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

        if(Input.GetButtonDown("Jump") && _isGrounded == true)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private float _tiempoInicioNube = 0f;
    private void OnTriggerStay2D(Collider2D otroCollider)
    {
        switch (otroCollider.gameObject.name)
        {
            case "Olor":
                if(_rastro != null)
                {
                    if(_tiempoInicioNube == 0)
                    {
                        _rastro.dañarRastro(0.1f);
                    }
                    
                }
                break;
        }
    }
}