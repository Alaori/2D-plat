using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GetInput : MonoBehaviour
{
    private Controls control;

    public float valueX;
    public bool jumpInupt;
    public bool tryAttack;

    public float valueY;
    public bool startClimb;
    private void Awake()
    {
        control = new Controls();
    }

    private void OnEnable()
    {
        control.Player.Move.performed += StartMove;
        control.Player.Move.canceled += StopMove;
        control.Player.Jump.performed += StartJump;
        control.Player.Jump.canceled += StopJump;
        control.Player.Attack.performed += StartAttack;
        control.Player.Attack.canceled += StopAttack;
        control.Player.Climb.performed += ClimbStart;
        control.Player.Climb.canceled += ClimbStop;
        control.Player.Enable();
    }
    private void OnDisable()
    {
        control.Player.Move.performed -= StartMove;
        control.Player.Move.canceled -= StopMove;
        control.Player.Jump.performed -= StartJump;
        control.Player.Jump.canceled -= StopJump;
        control.Player.Attack.performed -= StartAttack;
        control.Player.Attack.canceled -= StopAttack;
        control.Player.Climb.performed -= ClimbStart;
        control.Player.Climb.canceled -= ClimbStop;
        control.Player.Disable();

    }
    private void StartMove(InputAction.CallbackContext ctx)
    {
        valueX = ctx.ReadValue<float>();
    }
    private void StopMove(InputAction.CallbackContext ctx)
    {
        valueX = 0;
    }

    private void StartJump(InputAction.CallbackContext ctx)
    {
        jumpInupt = true;
    }
    private void StopJump(InputAction.CallbackContext ctx)
    {
        jumpInupt = false;
    }
    public void DisableControls()
    {
        control.Player.Move.performed -= StartMove;
        control.Player.Move.canceled -= StopMove;
        control.Player.Jump.performed -= StartJump;
        control.Player.Jump.canceled -= StopJump;
        control.Player.Climb.performed -= ClimbStart;
        control.Player.Climb.canceled -= ClimbStop;
        control.Player.Disable();
        valueX = 0;
    }
    private void StartAttack(InputAction.CallbackContext ctx)
    {
        tryAttack = true;
    }
    private void StopAttack(InputAction.CallbackContext ctx)
    {
        tryAttack = false;
        
    }
    private void ClimbStart(InputAction.CallbackContext ctx)
    {
        valueY = Mathf.RoundToInt(ctx.ReadValue<float>());
        if(Mathf.Abs(valueY) >0)
        {
            startClimb = true;
        }
    }

    private void ClimbStop(InputAction.CallbackContext ctx)
    {
        startClimb = false;
        valueY = 0;

    }
    
}
