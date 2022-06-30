using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishButton : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;
    IEnumerator ClickButton()
    {
        _audio.Play();
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(0);
    }
    public void ClickButtonToMainMenu()
    {
        StartCoroutine(ClickButton());
    }
}
