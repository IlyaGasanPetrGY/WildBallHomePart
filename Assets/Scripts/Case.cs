using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Case : MonoBehaviour
{
    [SerializeField] private GameObject _case;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _spawn; 

    private Rigidbody _playerRB;
    public void KillerPlayersald()
    {

        _case.gameObject.SetActive(false);
        _player.transform.position = _spawn.transform.position;
        _player.GetComponent<Rigidbody>().isKinematic = false;
    }
    /*{
        
}    */
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _playerRB = other.GetComponent<Rigidbody>();
            _playerRB.isKinematic = true;
            _case.gameObject.SetActive(true);
            _case.transform.position = new Vector3(other.transform.position.x, other.transform.position.y-0.5f, other.transform.position.z - 1);
          // _case.transform.LookAt(other.transform);
        }
    }


   
      


}
