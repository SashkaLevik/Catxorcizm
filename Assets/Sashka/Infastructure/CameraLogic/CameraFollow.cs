using Assets.Sashka.Scripts.Enemyes;
using System;
using System.Collections;
using System.Collections.Generic;
using CodeBase.Infrastructure.UI;
using UnityEngine;
using Assets.CodeBase.Player;

namespace Assets.Sashka.Infastructure.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        private const string MusicVolume = "MusicVolume";

        [SerializeField] protected float _speed;
        [SerializeField] protected SpawnerController _spawnerController;
        [SerializeField] protected AudioSource _portMusic;

        protected float _currentSpeed;
        protected PlayerMove _playerMove;
        private Camera _camera;

        private void Start()
        {
            if(!PlayerPrefs.HasKey(MusicVolume))
            {
                _portMusic.volume = 1;
            }
            else
                _portMusic.volume = PlayerPrefs.GetFloat(MusicVolume);

            _camera = Camera.main;            
            _currentSpeed = _speed;
            _portMusic.Play();
            StopMoving();
            StartCoroutine(nameof(GetPlayer));
        }       

        private void FixedUpdate()
            => transform.position += Vector3.right * _currentSpeed * Time.deltaTime;

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

        private IEnumerator GetPlayer()
        {
            yield return new WaitForSeconds(1);
            _playerMove = _camera.GetComponentInChildren<PlayerMove>();
        }

        public void SetDefaultSpeed()
        {
            _currentSpeed = _speed;
            if (_playerMove != null)
            {
                _playerMove.Move();
            }            
        }

        public void StopMoving()
        {
            _currentSpeed = 0;
            if (_playerMove != null)
            {
                _playerMove.Stop();
            }
        }
    }
}