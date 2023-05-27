using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sashka.Infastructure.CameraLogic
{
    public class CameraFollow : MonoBehaviour
    {
        //[SerializeField] private Transform _followTarget;
        [SerializeField] private float _speed;

        private void FixedUpdate()
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
        }
    }
}