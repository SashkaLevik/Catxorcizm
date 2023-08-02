using Assets.Sashka.Scripts.Enemyes;
using UnityEngine;

namespace Assets.Sashka.Infastructure.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private SpawnerController _spawnerController;
        [SerializeField] private AudioSource _portMusic;
        private float _currentSpeed;

        private void Start()
        {
            _currentSpeed = _speed;
            StopMoving();
            _portMusic.Play();
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

        private void SetDefaultSpeed()
            => _currentSpeed = _speed;

        public void StopMoving()
            => _currentSpeed = 0;
    }
}