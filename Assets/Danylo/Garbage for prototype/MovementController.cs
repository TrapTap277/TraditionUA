using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MovementController : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Rigidbody _rb;
    private Vector3 moveDirectionZ;


    public void MoveCharacter(Vector3 moveDirection, float moveMagnitude)
    {
        moveDirectionZ = moveDirection * _speed;
    }

    private void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + moveDirectionZ * Time.fixedDeltaTime);
    }
}
