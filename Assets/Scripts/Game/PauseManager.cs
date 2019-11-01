using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems; //new

public class PauseManager : MonoBehaviour
{
    [SerializeField] private bool isPaused = false;
    public GameObject pausePanel;   
    public GameObject inventoryPanel;
    public string mainMenu;
    public bool usingPausePanel;
    

    // new
    public EventSystem eventSystem; 
    public GameObject resumeButton;
    public GameObject backButton;
    public Slider magicSlider;
    
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
        usingPausePanel = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            Resume();
        }
        
    }

    public void Resume()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            magicSlider.enabled = false;
            Time.timeScale = 0f;
            usingPausePanel = true;
        }
        else
        {
            inventoryPanel.SetActive(false);
            pausePanel.SetActive(false);
            magicSlider.enabled = true;
            Time.timeScale = 1f;
        }
    }

    public void SwitchPanels()
    {
        usingPausePanel = !usingPausePanel;
        if (usingPausePanel)
        {
            pausePanel.SetActive(true);
            inventoryPanel.SetActive(false);
            eventSystem.SetSelectedGameObject(resumeButton); //new
        }
        else
        {
            inventoryPanel.SetActive(true);
            pausePanel.SetActive(false);
            eventSystem.SetSelectedGameObject(backButton); //new
        }
    }

    public void QuitToMain()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }


}

