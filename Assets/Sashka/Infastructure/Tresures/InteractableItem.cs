using Assets.Sashka.Scripts.Enemyes;
using UnityEngine;

namespace Assets.Sashka.Infastructure.Tresures
{
    public class InteractableItem : MonoBehaviour
    {
        [SerializeField] private PrizeSoul _prizeSoul;

        private void OnMouseOver()
            => transform.localScale = new Vector3(1.3f, 1.3f, 0);

        private void OnMouseExit()
            => transform.localScale = new Vector3(1, 1, 0);

        private void OnMouseDown()
        {
            Instantiate(_prizeSoul, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
