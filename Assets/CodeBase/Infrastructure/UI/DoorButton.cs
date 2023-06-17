using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.Infrastructure.UI
{
    public class DoorButton : MonoBehaviour
    {
        [SerializeField] private AudioSource _open;
        [SerializeField] private AudioSource _close;

        public void OpenDoor()
            => _open.Play();

        public void CloseDoor()
            => _close.Play();       
    }
}
