using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationsController : MonoBehaviour
{

    [HideInInspector]
    public bool isSniffing = false;

    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer body;
    private PlayerMovementController moveCtrl;
    private PlayerNarizController _narizController;

    private int timesWithZero;

    // Start is called before the first frame update
    void Start()
    {
        timesWithZero = 0;
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        body = GetComponentInChildren<SpriteRenderer>();
        moveCtrl = GetComponent<PlayerMovementController>();
        _narizController = GetComponent<PlayerNarizController>();
    }

    // Update is called once per frame
    void FixedUpdate()
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

        if (_rigidbody.velocity.x == 0f) timesWithZero++;
        if (_rigidbody.velocity.x != 0f) timesWithZero = 0;
        if (timesWithZero > 3 || _rigidbody.velocity.x != 0f)
        {
            timesWithZero=0;
            _animator.SetFloat("Speed", Mathf.Abs(_rigidbody.velocity.x));
        }
        _animator.SetBool("Grounded", moveCtrl.IsGrounded());
        if (Input.GetButtonDown("Jump") && moveCtrl.IsGrounded() && moveCtrl.GetSpeed().y == 0f)
        {
            _animator.SetBool("Jump", true);
        }
        if (Input.GetButtonDown("Fire1") && _narizController.cercaDeObjetoOlible() && moveCtrl.IsGrounded())
        {
            _animator.SetBool("Sniff", true);
        }

    }

}
