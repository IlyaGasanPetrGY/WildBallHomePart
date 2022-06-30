using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _rulls;
    [SerializeField] private Button _aboutGame;
    [SerializeField] private Button _selectLevels;
    [SerializeField] private GameObject _titleText;
    [SerializeField] private GameObject _rulsGameO;
    [SerializeField] private GameObject _aboutGameGameO;
    [SerializeField] private GameObject _selectLevelGameO;
    [SerializeField] private AudioSource _audioS;
    private Vector2 _defaultPos;
    # region Ruls
    public void ClickButtonRuls()
    {
        _audioS.Play();

        _defaultPos = _rulls.transform.position;
        _rulls.transform.position = _titleText.transform.position;
        _rulls.interactable = false;
        _titleText.SetActive(false);
        _aboutGame.gameObject.SetActive(false);
        _selectLevels.gameObject.SetActive(false);
        _rulsGameO.SetActive(true);
    }
    public void ClickBackButtonRuls()
    {
        _audioS.Play();

        _rulls.transform.position = _defaultPos;

        _rulls.interactable = true;
        _titleText.SetActive(true);
        _aboutGame.gameObject.SetActive(true);
        _selectLevels.gameObject.SetActive(true);
        _rulsGameO.SetActive(false);
    }
    #endregion 

    #region AboutGame
    public void ClickButtonAboutGame()
    {
        _audioS.Play();

        _defaultPos = _aboutGame.transform.position;
        _aboutGame.transform.position = _titleText.transform.position;
        _aboutGame.interactable = false;
        _titleText.SetActive(false);
        _rulls.gameObject.SetActive(false);
        _selectLevels.gameObject.SetActive(false);
        _aboutGameGameO.SetActive(true);
    }
    public void ClickBackAboutGame()
    {
        _audioS.Play();

        _aboutGame.transform.position = _defaultPos;

        _aboutGame.interactable = true;
        _titleText.SetActive(true);
        _rulls.gameObject.SetActive(true);
        _selectLevels.gameObject.SetActive(true);
        _aboutGameGameO.SetActive(false);
    }
    #endregion

    #region SelectLevel
    public void ClickButtonSelectLevel()
    {
        _audioS.Play();

        _defaultPos = _selectLevels.transform.position;
        _selectLevels.transform.position = _titleText.transform.position;
        _selectLevels.interactable = false;
        _titleText.SetActive(false);
        _rulls.gameObject.SetActive(false);
        _aboutGame.gameObject.SetActive(false);
        _selectLevelGameO.SetActive(true);
    }
    public void ClickBackSelectLevel()
    {
        _audioS.Play();

        _selectLevels.transform.position = _defaultPos;

        _selectLevels.interactable = true;
        _titleText.SetActive(true);
        _rulls.gameObject.SetActive(true);
        _aboutGame.gameObject.SetActive(true);
        _selectLevelGameO.SetActive(false);
    }
    #endregion
    
    #region Levels
    IEnumerator LoadSceneGame(int numberscene)
    {
        _audioS.Play();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(numberscene);
    }
    public void ClickFirstLevel()
    {
        StartCoroutine(LoadSceneGame(1));
    }
    public void ClickSecondLevel()
    {
        StartCoroutine(LoadSceneGame(2));
    }
    public void ClickThirdLevel()
    {
        StartCoroutine(LoadSceneGame(3));
    }

    #endregion
}
