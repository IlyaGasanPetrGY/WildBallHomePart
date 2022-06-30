using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace GlobalSTRVar
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : SceneController
    {
        private Rigidbody _rb;
        private Animator _anim;
        private bool _readyJump =true;
        public static float jumpForse = 250;
        public float timerBonus;
        [SerializeField] private Image _imgTime;

        
        private void OnCollisionEnter(Collision collision)
        {
            _readyJump = true;
            
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "jump")
            {
                timerBonus = 5f;
            }
        }
        [SerializeField, Range(1, 10)] private float _speed = 2f;
        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            _anim = GetComponent<Animator>();
        }
        private void Update()
        {
            float _horizontal = Input.GetAxis(GlobalNameSTRValue.HORIZONTAL_AXIS);
            float _vertiacl = Input.GetAxis(GlobalNameSTRValue.VERTICAL_AXIS);
            float _jump = 0;
            if (_readyJump)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    _jump = Input.GetAxis(GlobalNameSTRValue.JUMP);
                    _readyJump = false;
                }
            }
            Vector3 ForceVec = new Vector3(-_horizontal*_speed, _jump*jumpForse, -_vertiacl*_speed);
            _rb.AddForce(ForceVec);
            _anim.SetFloat("Velocity", _rb.velocity.magnitude);
            if (timerBonus > 0)
            {
                timerBonus -= Time.deltaTime;
                _imgTime.fillAmount = timerBonus / 5;
                jumpForse = 250 * 2;
            }
            else
            {
                jumpForse = 250f;
            }
        }
        

    }
}
