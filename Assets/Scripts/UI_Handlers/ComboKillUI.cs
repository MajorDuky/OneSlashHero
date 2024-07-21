using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ComboKillUI : MonoBehaviour
{
    [SerializeField] private Slider comboTimeSlider;
    [SerializeField] private TMP_Text comboKillText;
    [SerializeField] private Image comboTimeSliderFill;
    private Color timerNiceColor;
    private Color timerWarningColor;
    private Color timerDangerColor;

    private void OnEnable()
    {
        comboTimeSlider.maxValue = 4f;
        timerNiceColor = new Color(0, 255, 21, 255);
        timerWarningColor = new Color(255, 208, 0, 255);
        timerDangerColor = new Color(255, 29, 0, 255);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChainKill(int chainCount)
    {
        comboTimeSlider.value = comboTimeSlider.maxValue;
        comboKillText.text = $"X {chainCount}";
    }

    public void UpdateChainKillSlider(float value)
    {
        if(value > comboTimeSlider.maxValue/2)
        {
            comboTimeSliderFill.color = timerNiceColor;
        }
        else if(value > comboTimeSlider.maxValue / 4)
        {
            comboTimeSliderFill.color = timerWarningColor;
        }
        else if (value < comboTimeSlider.maxValue / 4)
        {
            comboTimeSliderFill.color = timerDangerColor;
        }
        comboTimeSlider.value = value;
    }
}
