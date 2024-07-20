using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyColorSphere : MonoBehaviour
{
    [HideInInspector] public Color sphereColor;
    private Renderer sphereRenderer;

    // Start is called before the first frame update
    void Start()
    {
        sphereRenderer = GetComponent<Renderer>();
        Color randomPickedInAvailableColors = ColorSystemManager.colorList[Random.Range(0, ColorSystemManager.colorList.Count)];
        sphereRenderer.material = new Material(Shader.Find("Standard"));
        sphereRenderer.material.color = randomPickedInAvailableColors;
        sphereColor = randomPickedInAvailableColors;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
