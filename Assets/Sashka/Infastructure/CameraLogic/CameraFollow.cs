using Assets.Sashka.Infastructure.UI;
using Assets.Sashka.Scripts.Enemyes;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sashka.Infastructure.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private SpawnerController _spawnerController;
        [SerializeField] private GameScreen _gameScreen;

        private float _currentSpeed;

        private void Start()
            => _currentSpeed = _speed;

        private void FixedUpdate()
            => transform.position += Vector3.right * _currentSpeed * Time.deltaTime;

        private void OnEnable()
        {
            _spawnerController.WaveCompleted += StopMoving;
            _gameScreen.WaveStarted += SetDefaultSpeed;
        }

        private void StopMoving()
            => _currentSpeed = 0;

        private void SetDefaultSpeed()
            => _currentSpeed = _speed;
    }
}