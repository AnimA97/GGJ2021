using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{

    [HideInInspector]
    public bool isSniffing;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer body;
    private PlayerMovementController moveCtrl;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        body = GetComponentInChildren<SpriteRenderer>();
        moveCtrl = GetComponent<PlayerMovementController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isSniffing || (GameSystem.instance != null && GameSystem.instance.isPaused()))
        {
            _animator.speed = 0f;
            return;
        }
        _animator.speed = 1f;

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput < 0f)
        {
            if (!body.flipX) _animator.SetInteger("Turn", -1);
            //body.flipX = true;
        }
        else if (horizontalInput > 0f)
        {
            if (body.flipX) _animator.SetInteger("Turn", 1);
            //body.flipX = false;
        }

        _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
        _animator.SetBool("Grounded", moveCtrl.IsGrounded());
        if (Input.GetButtonDown("Jump") && moveCtrl.IsGrounded())
        {
            _animator.SetBool("Jump", true);
        }
        if (Input.GetButtonDown("Fire1") && moveCtrl.IsGrounded())
        {
            _animator.SetBool("Sniff", true);
        }

    }
}
