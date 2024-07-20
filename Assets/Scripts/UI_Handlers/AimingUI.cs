using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AimingUI : MonoBehaviour
{
    [SerializeField] private Image aimingCircle;
    [SerializeField] private Image aimingArrow;

    public void SlashModeActivation()
    {
        aimingCircle.gameObject.SetActive(true);
        aimingArrow.gameObject.SetActive(true);
    }

    public void SlashModeDeactivation()
    {
        aimingCircle.gameObject.SetActive(false);
        aimingArrow.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
