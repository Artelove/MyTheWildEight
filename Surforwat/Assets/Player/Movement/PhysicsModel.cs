using UnityEngine;

namespace Movement
{
    public class PhysicsModel
    {
        private PhysicsMovement _phisicsMovement;
        private PhysicsInput _input;

        public PhysicsModel(UnitPhysicsConfig physicsConfig, Rigidbody rigidbody, PhysicsInput input)
        {
            _input = input;
            _phisicsMovement = new PhysicsMovement(physicsConfig, rigidbody);
        }
        
        public void UpdatePosition(float fixedTime)
        {
            _phisicsMovement.Movement(_input.HorizontalAxis, _input.VerticalAxis, fixedTime);
        }
    }
}