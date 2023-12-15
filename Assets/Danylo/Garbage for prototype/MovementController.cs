using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody _rb;

    private Vector3 _movement;
    void Update()
    {
        _movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;

    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position +  _movement * _speed * Time.fixedDeltaTime);
    }
}
