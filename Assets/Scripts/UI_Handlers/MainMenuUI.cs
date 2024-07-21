using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private RectTransform launchBtns;
    [SerializeField] private RectTransform playBtns;
    [SerializeField] private RectTransform settingsSection;
    [SerializeField] private RectTransform tutorialSection;
    [SerializeField] private RectTransform tutoSlides;
    [SerializeField] private Button nextButton;
    private int currentTutoSlideId;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayBtnPress()
    {
        launchBtns.gameObject.SetActive(false);
        playBtns.gameObject.SetActive(true);
        playBtns.GetChild(0).GetComponent<Button>().Select();
    }

    public void ReturnBtnPress()
    {
        launchBtns.gameObject.SetActive(true);
        playBtns.gameObject.SetActive(false);
        launchBtns.GetChild(0).GetComponent<Button>().Select();
    }

    public void SettingsBtnPress()
    {
        launchBtns.gameObject.SetActive(false);
        settingsSection.gameObject.SetActive(true);
        // launchBtns.GetChild(0).GetComponent<Button>().Select();
    }

    public void ReturnSettingsBtnPress()
    {
        launchBtns.gameObject.SetActive(true);
        settingsSection.gameObject.SetActive(false);
        launchBtns.GetChild(0).GetComponent<Button>().Select();
    }

    public void TutorialBtnPress()
    {
        launchBtns.gameObject.SetActive(false);
        tutorialSection.gameObject.SetActive(true);
        nextButton.Select();
    }

    public void NextTutoBtnPress()
    {
        Debug.Log(tutoSlides.childCount);
        if(currentTutoSlideId < tutoSlides.childCount -1)
        {
            tutoSlides.GetChild(currentTutoSlideId).gameObject.SetActive(false);
            currentTutoSlideId++;
            tutoSlides.GetChild(currentTutoSlideId).gameObject.SetActive(true);
        }
        else
        {
            tutorialSection.gameObject.SetActive(false);
            launchBtns.gameObject.SetActive(true);
            launchBtns.GetChild(0).GetComponent<Button>().Select();
        }

    }
}
