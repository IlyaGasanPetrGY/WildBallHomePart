using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoores : MonoBehaviour
{
    private Animator _anim;

    private bool _isStaing;
    private void Awake()
    {
        _anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        _isStaing = true;
    }
    private void OnTriggerExit(Collider other)
    {
        _isStaing = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _anim.SetTrigger("Open");
        }
    }
}
