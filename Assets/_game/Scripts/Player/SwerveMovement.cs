using System;
using UnityEngine;

namespace _game.Scripts.Player
{
    public class SwerveMovement : MonoBehaviour
    {
        private InputManager _swerveInputSystem;
        [SerializeField] private float swerveSpeed = 0.5f;
        private Rigidbody _rigidbody;

        private void Awake()
        {
            _swerveInputSystem = GetComponent<InputManager>();
        }

        private void Update()
        {
            float swerveAmount = Time.deltaTime * swerveSpeed * _swerveInputSystem.MoveFactorX;
            transform.Translate(swerveAmount,0,0);
        }
    }
}