using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimingController : MonoBehaviour
{
    private OneSlashHero inputActions;
    private InputAction rotateAimDirection;
    private InputAction slash;
    private Quaternion baseRotation;

    private void Awake()
    {
        inputActions = new OneSlashHero();
    }

    private void OnEnable()
    {
        baseRotation = transform.rotation;
        rotateAimDirection = inputActions.Player.RotateAimDirection;
        rotateAimDirection.Enable();
        slash = inputActions.Player.Slash;
        slash.performed += OnSlash;
    }

    private void OnDisable()
    {
        rotateAimDirection.Disable();
        slash.performed -= OnSlash;
    }

    private void OnSlash(InputAction.CallbackContext context)
    {

    }

    private void Update()
    {
        Vector2 rotateAimVector = rotateAimDirection.ReadValue<Vector2>();
        Quaternion targetRotation;
        if (rotateAimVector != Vector2.zero)
        {
            float angle = (Mathf.Atan2(rotateAimVector.y, -rotateAimVector.x) * Mathf.Rad2Deg) - 90f;
            targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
            
        }
        else
        {
            targetRotation = baseRotation;
        }
        transform.rotation = targetRotation;
    }
}
