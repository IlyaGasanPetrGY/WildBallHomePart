using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class DeathController : MonoBehaviour
{
    private Text _countLives;
    private Animator _playerAnim;
    private GameObject _spawnPos;
    private Rigidbody _rb;
    private Transform _player;
    [SerializeField] ParticleSystem _particleSystem;
    
    private void Awake()
    {
        //_countLives = GameObject.FindGameObjectWithTag("LivePoints").GetComponent<Text>();
        
        _playerAnim = GetComponent<Animator>();
        _spawnPos = GameObject.FindGameObjectWithTag("Respawn");
        _rb = GetComponent<Rigidbody>();
        _player = transform;
    }
    private void SetActivePlayer()
    {

        _particleSystem.Emit(20);
    }
    public void PlayAnimDead()
    {
        //_countLives.text = (Convert.ToInt32(_countLives.text) -  1).ToString();
        _rb.isKinematic = true;
        _playerAnim.SetTrigger("Dead");
        foreach (Collider COL in _player.GetComponents<SphereCollider>())
        {
            Destroy(COL);
        }
    }
    public void Respawn()
    {
        _rb.isKinematic = false;
        
        _player.position = _spawnPos.transform.position;
        
        _playerAnim.SetTrigger("Spawn");
        foreach (Collider COL in _player.GetComponents<SphereCollider>())
        {
            Destroy(COL);
        }
        _player.gameObject.AddComponent<SphereCollider>();
        
    }
    public void ParticleSystemBoom()
    {
        _particleSystem.Emit(20);
    }
    public void Kill()
    {
        PlayAnimDead();
        Invoke("ParticleSystemBoom", 0.5f);
        Invoke("Respawn", 2f);

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Keller")
        {
            Kill();
        }
        if (other.tag == "GamePlane")
        {
            _player.position = _spawnPos.transform.position;
            _rb.velocity = new Vector3(0, 0, 0);
        }
    }
}
