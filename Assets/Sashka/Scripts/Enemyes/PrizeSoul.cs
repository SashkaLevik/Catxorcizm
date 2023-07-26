using System.Collections;
using UnityEngine;

namespace Assets.Sashka.Scripts.Enemyes
{
    public class PrizeSoul : Soul
    {
        public override void Start()
        {
            _target = GameObject.FindGameObjectWithTag(SoulCounter);
            StartCoroutine(Fly());
            _reward = 10;
        }

        public override IEnumerator Fly()
        {            
            yield return StartCoroutine(MoveToTarget(transform, _target.transform.position));
        }
    }
}