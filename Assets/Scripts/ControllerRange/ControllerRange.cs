using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRange : MonoBehaviour
{
    private GameObject _player;
    private Vector3 _dist;
    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _dist = _player.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _player.transform.position - _dist;
    }
}
