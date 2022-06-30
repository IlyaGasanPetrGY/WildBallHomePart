using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour
{
    [SerializeField] private GameObject _canvasNewLevel;
    [SerializeField] private GameObject _canvasPause;
    [SerializeField] private GameObject _textCollectCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            if (other.tag == "Player" && ButtonsForMenuPause._countCollect == ButtonsForMenuPause._countCoins)
            {
                Time.timeScale = 0;
                _canvasNewLevel.SetActive(true);
                _canvasPause.SetActive(false);

                // ButtonsForMenuPause.TernOfPause();
            }
            else if (other.tag == "Player" && ButtonsForMenuPause._countCollect != ButtonsForMenuPause._countCoins)
            {
                _textCollectCoin.SetActive(true);
            }
        }
        else
        {
            if (other.tag == "Player" && ButtonsForMenuPause._countCollect == ButtonsForMenuPause._countCoins)
            {
                SceneManager.LoadScene(4);

            }
        }

    }
    private void OnTriggerExit(Collider other)
    {
        _textCollectCoin.SetActive(false);
    }
}
