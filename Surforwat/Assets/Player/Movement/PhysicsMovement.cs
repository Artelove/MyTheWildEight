
using System.Collections.Generic;
using Movement;
using Units;
using UnityEngine;

public class PhysicsMovement
{
    protected float _moveSpeed;
    protected Rigidbody rigidbody;

    public PhysicsMovement(UnitPhysicsConfig unitPhysicsConfig, Rigidbody rigidbody)
    {
        _moveSpeed = unitPhysicsConfig.MoveSpeed;
        this.rigidbody = rigidbody;
    }
    public void Movement(float horizontalAxis, float verticalAxis, float time)
    {
        Vector3 move = new Vector3(horizontalAxis * _moveSpeed, 0, verticalAxis * _moveSpeed);
        
        Move(move*time);
    }
    private void Move(Vector3 move) {
        rigidbody.MovePosition(rigidbody.position + move);
    }
}
