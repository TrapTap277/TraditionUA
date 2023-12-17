using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickForMovement : JoystickHandler
{
    [SerializeField] private MovementController characterMovement;

    private void Update()
    {
        if (_inputVector.x != 0 || _inputVector.y != 0)
        {
            characterMovement.MoveCharacter(new Vector3(_inputVector.x, 0, _inputVector.y), _inputVector.magnitude);
        }
        else
        {
            _inputVector = Vector2.zero;
            characterMovement.MoveCharacter(new Vector3(_inputVector.x, 0, _inputVector.y), _inputVector.magnitude);
        } 
    }

}
