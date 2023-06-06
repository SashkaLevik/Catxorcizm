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

        private float _currentSpeed;

        private void Start()
        {
            _currentSpeed = _speed;
        }

        private void FixedUpdate()
        {
            transform.position += Vector3.right * _currentSpeed * Time.deltaTime;

        }

        private void OnEnable()
        {
            //_spawnerController.CurrentSpawner.WaveCompleted += StopMoving;
        }

        private void StopMoving()
        {
            Debug.Log("Stoped");
            //_currentSpeed = 0;
        }
    }
}