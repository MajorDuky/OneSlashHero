using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorSystemManager : MonoBehaviour
{
    public Color firstColor;
    public Color secondColor;
    public Color thirdColor;
    public Color fourthColor;
    public static ColorSwitcherHitEvent onColorSwitchHit = new ColorSwitcherHitEvent();
    [HideInInspector] public static List<Color> colorList = new List<Color>();
    [SerializeField] private List<Vector3> spawnColorSwitcherSpots = new List<Vector3>();
    [SerializeField] private ColorSwitcher colorSwitcher;
    [SerializeField] private Transform colorSwitchersContainer;
    private List<ColorSwitcher> colorSwitcherList = new List<ColorSwitcher>();
    [SerializeField] private SlashController slashController;
    private void OnEnable()
    {
        onColorSwitchHit.AddListener(AnswerToColorSwitchHit);
    }

    // Start is called before the first frame update
    void Start()
    {
        colorList.Add(firstColor);
        colorList.Add(secondColor);
        colorList.Add(thirdColor);
        colorList.Add(fourthColor);
        int colorSwitcherSpawnId = 0;
        foreach (var color in colorList)
        {
            ColorSwitcher clone = Instantiate(colorSwitcher, colorSwitchersContainer);
            clone.gameObject.transform.position = spawnColorSwitcherSpots[colorSwitcherSpawnId];
            clone.switchColor = color;
            colorSwitcherList.Add(clone);
            colorSwitcherSpawnId++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void AnswerToColorSwitchHit(Color colorHit)
    {
        slashController.SwitchSlashColor(colorHit);
        foreach (var colorSwitcher in colorSwitcherList)
        {
            if(colorSwitcher.switchColor != colorHit)
            {
                colorSwitcher.ColorSwitchAvailable();
            }
        }
    }
}

public class ColorSwitcherHitEvent : UnityEvent<Color> { }