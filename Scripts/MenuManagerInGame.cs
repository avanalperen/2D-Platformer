using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject inGameScreen, PauseScreen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        PauseScreen.SetActive(true);
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        PauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }

    public void ReplayButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void HomeButton()
    {
        Time.timeScale = 1;
        
        DataManager.Instance.SaveData();

        SceneManager.LoadScene(0);
        
    }
}
