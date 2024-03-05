using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestState : PlayerBaseState
{
    public PlayerTestState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    public override void Enter()
    {
    }

    public override void Tick(float deltaTime)
    {
        Vector3 movement = new Vector3();

        movement.x = stateMachine.InputReader.MovementValue.x;
        movement.y = 0; 
        movement.z = stateMachine.InputReader.MovementValue.y;

        stateMachine.Controller.Move(movement * stateMachine.FreeLookMovementSpeed * Time.deltaTime);

        // If not moving, do nothing.
        if (stateMachine.InputReader.MovementValue == Vector2.zero)  
        {
            stateMachine.Animator.SetFloat("FreeLookSpeed", 0, 0.1f, deltaTime);
            return;
        }

        stateMachine.Animator.SetFloat("FreeLookSpeed", 1, 0.1f, deltaTime);
        stateMachine.transform.rotation = Quaternion.LookRotation(movement);    // If you are moving, rotate.

    }

    public override void Exit()
    {

    }

}
