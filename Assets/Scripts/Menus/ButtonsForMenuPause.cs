using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsForMenuPause : MonoBehaviour
{
    public GameObject _pause;
    public GameObject _nextLevel;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private AudioSource _audioClick;
    [SerializeField] private Text _score;
    public static int _countCoins; 
    public static int _countCollect = 0;
    private void Awake()
    {
        _countCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        _score.text = _countCollect.ToString() +  "/" + _countCoins.ToString();
        _countCollect = 0;
    }
    private void Update()
    {
        
        _score.text = _countCollect.ToString() +  "/" + _countCoins.ToString();
    }
    #region LoadScene
    private void LoadMainMenu()
    {
        _countCollect = 0;
        SceneManager.LoadScene(0);
        
    }
    private void LoadCurrentLevel()
    {
        _countCollect = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void LoadNextLevel()
    {
        _countCollect = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    #endregion
    #region Corutines
    
    public IEnumerator ClickToMainMenuCorutine()
    {
        _audioClick.Play();
        yield return new WaitForSecondsRealtime(0.2f);
        LoadMainMenu();
        Time.timeScale = 1;

    }
    public IEnumerator ClickToRestartLevelCorutine()
    {
        _audioClick.Play();
        yield return new WaitForSecondsRealtime(0.2f);
        LoadCurrentLevel();
        Time.timeScale = 1;

    }
    public IEnumerator ClickButtonNextLevelCorutine()
    {
        _audioClick.Play();
        yield return new WaitForSecondsRealtime(0.2f);
        LoadNextLevel();
        Time.timeScale = 1;
    }
    #endregion
    #region ClicksButton
    public void ClickToMainMenu()
    {
        StartCoroutine(ClickToMainMenuCorutine());
    }
    public void ClickToRestartLevel()
    {
        StartCoroutine(ClickToRestartLevelCorutine());

    }
    public void ClickPauseButton()
    {
        if (Time.timeScale != 0)
        {
            
            _pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            _pauseMenu.SetActive(false);
        }
    }
    public void ClickButtonNextLevel()
    {
        StartCoroutine(ClickButtonNextLevelCorutine());
    }

    #endregion
    /*public static void TernOfPause()
    {
        _pause.SetActive(false);
        _nextLevel.SetActive(true);
    }*/
}
