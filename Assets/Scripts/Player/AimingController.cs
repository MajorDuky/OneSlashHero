using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AimingController : MonoBehaviour
{
    private OneSlashHero inputActions;
    private InputAction rotateAimDirection;
    private Quaternion baseRotation;
    [SerializeField] private PlayerAnimationController animator;

    private void Awake()
    {
        inputActions = new OneSlashHero();
    }

    private void OnEnable()
    {
        baseRotation = transform.rotation;
        rotateAimDirection = inputActions.Player.RotateAimDirection;
        rotateAimDirection.Enable();
    }

    private void OnDisable()
    {
        rotateAimDirection.Disable();
    }

    private void Update()
    {
        Vector2 rotateAimVector = rotateAimDirection.ReadValue<Vector2>();
        Quaternion targetRotation;
        if (rotateAimVector != Vector2.zero)
        {
            ActionsManager.onSlashModeEnter.Invoke();
            float angle = (Mathf.Atan2(rotateAimVector.y, -rotateAimVector.x) * Mathf.Rad2Deg) - 90f;
            targetRotation = Quaternion.AngleAxis(angle, Vector3.up);
            animator.Crouch();
        }
        else
        {
            targetRotation = baseRotation;
            animator.StopCrouching();
        }
        transform.rotation = targetRotation;
    }
}
