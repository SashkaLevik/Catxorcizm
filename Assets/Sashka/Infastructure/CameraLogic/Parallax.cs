using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Sashka.Infastructure.CameraLogic
{
    public class Parallax : MonoBehaviour
    {
        [SerializeField] private Vector2 _parallaxEffect;

        private Transform _cameraTransform;
        private Vector3 _lastCameraPos;
        private float _textureUnitSizeX;

        private void Start()
        {
            _cameraTransform = Camera.main.transform;
            _lastCameraPos = _cameraTransform.position;
            Sprite sprite = GetComponent<SpriteRenderer>().sprite;
            Texture2D texture = sprite.texture;
            _textureUnitSizeX = texture.width / sprite.pixelsPerUnit;
        }

        private void LateUpdate()
        {
            Vector3 deltaMovement = _cameraTransform.position - _lastCameraPos;
            transform.position += new Vector3(deltaMovement.x * _parallaxEffect.x, deltaMovement.y * _parallaxEffect.y, 0);
            _lastCameraPos = _cameraTransform.position;

            //if (_cameraTransform.position.x - transform.position.x >= _textureUnitSizeX)
            //{
            //    float offsetPosX = (_cameraTransform.position.x - transform.position.x) % _textureUnitSizeX;
            //    transform.position = new Vector3(_cameraTransform.position.x + offsetPosX, transform.position.y);
            //}
        }
    }
}