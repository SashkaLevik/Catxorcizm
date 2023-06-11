using Assets.Sashka.Infastructure.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Sashka.Infastructure
{
    public class Loading : MonoBehaviour
    {
        public CanvasGroup Curtain;
        
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }        

        public void Show()
        {
            gameObject.SetActive(true);
            Curtain.alpha = 1;
        }

        public void Hide()
        {
            StartCoroutine(FadeIn());
        }


        private IEnumerator FadeIn()
        {
            while (Curtain.alpha > 0)
            {
                Curtain.alpha -= 0.03f;
                yield return new WaitForSeconds(0.03f);
            }
            gameObject.SetActive(false);
        }
    }
}
