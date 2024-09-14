using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private InputSystem_Actions _input;
    private IControlable _controlable;

    private void Awake()
    {
        _input = new InputSystem_Actions();
        _input.Enable();
        _controlable = GetComponent<IControlable>();

        _input.Player.Jump.performed += Jump_performed;
      //  _input.Player.Dash.performed += Dash_performed;
    }

    private void Dash_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _controlable.Dash();
    }

    private void Update()
    {
        ReadMovement();
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _controlable.Jump();
        Debug.Log("jumpPerformed");
    }

    private void ReadMovement()
    {
        Vector2 _inputDirection = _input.Player.Move.ReadValue<Vector2>();

        _controlable.Move(_inputDirection);
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
}