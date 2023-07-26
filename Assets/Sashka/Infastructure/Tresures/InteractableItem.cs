using Assets.Sashka.Scripts.Enemyes;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    public class InteractableItem : MonoBehaviour
    {
        [SerializeField] private PrizeSoul _prizeSoul;
        [SerializeField] private AudioSource _jingle;

        private void OnMouseDown()
        {
            _jingle.Play();
            Instantiate(_prizeSoul, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
