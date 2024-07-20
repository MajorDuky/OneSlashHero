using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlashController : MonoBehaviour
{
    private OneSlashHero inputActions;
    private InputAction slash;

    private void Awake()
    {
        inputActions = new OneSlashHero();
        slash = inputActions.Player.Slash;
        slash.performed += OnSlash;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnSlash(InputAction.CallbackContext context)
    {
        Debug.Log("Ouais ouais ouais");
    }

    public void SlashModeEnter()
    {
        slash.Enable();
    }

    public void SlashModeExit()
    {
        slash.Disable();
    }
}
