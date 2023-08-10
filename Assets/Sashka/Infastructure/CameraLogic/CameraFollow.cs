using Assets.Sashka.Scripts.Enemyes;
using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure.UI;
using UnityEngine;

namespace Assets.Sashka.Infastructure.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        private const string MusicVolume = "MusicVolume";
        [SerializeField] private float _speed;
        [SerializeField] private SpawnerController _spawnerController;
        [SerializeField] private AudioSource _portMusic;
        private float _currentSpeed;

        private void Start()
        {
            if(!PlayerPrefs.HasKey(MusicVolume))
            {
                _portMusic.volume = 1;
            }
            else
                _portMusic.volume = PlayerPrefs.GetFloat(MusicVolume);

            _currentSpeed = _speed;
            StopMoving();
            _portMusic.Play();
        }            

        private void FixedUpdate()
            => transform.position += Vector3.right * _currentSpeed * Time.deltaTime;

        //private void Update()
        //    => _portMusic.volume = PlayerPrefs.GetFloat(MusicVolume);

        private void OnEnable()
        {
            _spawnerController.WaveCompleted += StopMoving;
            _spawnerController.WaveStarted += SetDefaultSpeed;
            _spawnerController.LevelCompleted += StopMoving;
        }
        private void OnDisable()
        {
            _spawnerController.WaveCompleted -= StopMoving;
            _spawnerController.WaveStarted -= SetDefaultSpeed;
            _spawnerController.LevelCompleted -= StopMoving;
        }        

        private void SetDefaultSpeed()
            => _currentSpeed = _speed;

        public void StopMoving()
            => _currentSpeed = 0;
    }
}