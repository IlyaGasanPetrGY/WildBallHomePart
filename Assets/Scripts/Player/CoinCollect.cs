using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollect : MonoBehaviour
{
    private Animator _animatorContr;
    private void Awake()
    {
        _animatorContr = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _animatorContr.SetTrigger("CoinCollect");
            ButtonsForMenuPause._countCollect += 1;
        }
    }
    public void DestroerCoin()
    {
        Destroy(gameObject);
    }
}
