using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActionsManager : MonoBehaviour
{
    [SerializeField] private AimingController aimingController;
    [SerializeField] private SlashController slashController;
    [SerializeField] private AimingUI aimingUI;
    public static UnityEvent onSlashModeEnter = new UnityEvent();
    public static UnityEvent onSlashModeExit = new UnityEvent();

    private void OnEnable()
    {
        onSlashModeEnter.AddListener(AnswerToSlashModeEnter);
        onSlashModeExit.AddListener(AnswerToSlashModeExit);
    }

    private void OnDisable()
    {
        onSlashModeEnter.RemoveListener(AnswerToSlashModeEnter);
        onSlashModeExit.RemoveListener(AnswerToSlashModeExit);
    }

    private void AnswerToSlashModeEnter()
    {
        aimingUI.SlashModeActivation();
        slashController.SlashModeEnter();
    }

    private void AnswerToSlashModeExit()
    {
        aimingUI.SlashModeDeactivation();
        slashController.SlashModeExit();
    }
}
