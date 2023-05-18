using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _followTarget;
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {
        //transform.position = new Vector3(_followTarget.position.x, 0, -10);
        transform.position += Vector3.right * _speed * Time.deltaTime;
    }
}
