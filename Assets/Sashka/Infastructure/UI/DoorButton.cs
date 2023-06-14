using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace Assets.Sashka.Infastructure.UI
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
