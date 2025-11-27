using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 5.0f;

    public Rigidbody2D _rb;

    private Vector2 direction;

    private void Awake()
    {
        if (_rb == null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }
    }

    private void Update()
    {
        CheckInput();
    }

    private void FixedUpdate()
    {
        Move(); // eseguo il movimento in FixedUpdate per gestire il movimento con RigidBody
    }

    void CheckInput()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        direction = new Vector2(h, v); // crea vettore direzione

        if (direction.sqrMagnitude > 1f) direction = direction.normalized;
    }

    void Move()
    {
        _rb.MovePosition(_rb.position + direction * (_speed * Time.deltaTime)); //_rb.velocity = direction * _speed;
    }

}
