using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class ColorSwitcher : MonoBehaviour
{
    [HideInInspector] public Color switchColor;
    [SerializeField] private Renderer sphereRenderer;
    [HideInInspector] public bool canBeHit;
    public Light spot;

    // Start is called before the first frame update
    void Start()
    {
        sphereRenderer.material = new Material(Shader.Find("Standard"));
        sphereRenderer.material.color = switchColor;
        canBeHit = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColorSwitchHit()
    {
        ColorSystemManager.onColorSwitchHit.Invoke(switchColor);
        canBeHit = false;
        spot.gameObject.SetActive(false);
    }

    public void ColorSwitchAvailable()
    {
        canBeHit = true;
        spot.gameObject.SetActive(true);
    }
}
