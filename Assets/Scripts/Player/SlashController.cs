using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class SlashController : MonoBehaviour
{
    private OneSlashHero inputActions;
    private InputAction slash;
    private Color currentSlashColor;
    public static UnityEvent onObstacleOrWrongEnemyHit = new UnityEvent();
    [SerializeField] private TrailRenderer slashTrail;

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
        RaycastHit hit;
        if (Physics.Raycast(transform.position + new Vector3(0, 0.2f, 0), transform.TransformDirection(Vector3.forward), out hit, 50))
        {
            if (hit.collider.gameObject.layer == 6)
            {
                if (hit.collider.gameObject.GetComponent<EnemyBehaviorController>().sphereHandler.sphereColor == currentSlashColor)
                {
                    hit.collider.gameObject.GetComponent<EnemyBehaviorController>().EnemyHit();
                    Vector3 currentForward = transform.forward;
                    transform.position = hit.collider.transform.position + currentForward;
                }
                else
                {
                    onObstacleOrWrongEnemyHit.Invoke();
                }
                
            }
            else if (hit.collider.gameObject.layer == 7)
            {
                onObstacleOrWrongEnemyHit.Invoke();
            }
            else if (hit.collider.gameObject.layer == 8)
            {
                hit.collider.gameObject.GetComponent<ColorSwitcher>().ColorSwitchHit();
                Vector3 currentForward = transform.forward;
                transform.position = hit.collider.transform.position + currentForward;
            }
        }
    }

    public void SlashModeEnter()
    {
        slash.Enable();
    }

    public void SlashModeExit()
    {
        slash.Disable();
    }

    public void SwitchSlashColor(Color color)
    {
        currentSlashColor = color;
        Gradient gradient = new Gradient();
        var colors = new GradientColorKey[2];
        colors[0] = new GradientColorKey(color, 0.0f);
        colors[1] = new GradientColorKey(color, 1.0f);
        var alphas = new GradientAlphaKey[2];
        alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        alphas[1] = new GradientAlphaKey(1.0f, 0.0f);
        gradient.SetKeys(colors, alphas);
        slashTrail.colorGradient = gradient;
    }
}