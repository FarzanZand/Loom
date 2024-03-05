using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    // Whenever you press a button as defined in the input manager, Controls.cs
    // It will handle the logic, and call the method here. 
    // Create an event for press actions. The buttonpress OnX() calls the event, and all things subscribed to it react. 
    // Movement, you read a value instead. 

    public event Action JumpEvent;
    public event Action DodgeEvent;
    public Vector2 MovementValue { get; private set; }

    private Controls controls;

    private void Start()
    {
        controls = new Controls();
        controls.Player.SetCallbacks(this);     // Player is defined in the Input manager. This reference will now call the methods in this script

        controls.Player.Enable();
    }

    private void OnDestroy()                    // Called when the gameobject is destroyed. Dead players don't do stuff. 
    {
        controls.Player.Disable();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }     // Don't do anything if no action was taken

        if(JumpEvent != null)
            JumpEvent.Invoke();                 // Call all methods subscribed to jumpEvent;    
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed) { return; }     

        if (DodgeEvent != null)
            DodgeEvent.Invoke();                    
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();   // Whenever you hit the WASD or joystick, it reads the value. It knows which buttons since OnMove is connected to them in Controls
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        // Cinemachine uses this for us. We don't need to add any code here. 
    }
}
