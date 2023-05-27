using System.Collections;
using UnityEngine;

namespace Assets.Sashka.Infastructure
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}