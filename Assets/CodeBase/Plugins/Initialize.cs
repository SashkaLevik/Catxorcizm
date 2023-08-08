using System.Collections;
using Agava.YandexGames;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Plugins
{
    public class Initialize : MonoBehaviour
    {
        private const int _nameScene = 1;
        private const int textureQualityMobile = 2;
        private const int textureQuality = 4;
    

        private void Start()
        {
            RenderTexture.active.antiAliasing = Application.isMobilePlatform ? textureQualityMobile : textureQuality;
        }

        private void Awake()
        {
            StartCoroutine(Init());
        }

        private IEnumerator Init()
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            yield return new WaitForSeconds(0.1f);
#elif YANDEX_GAMES
        while(YandexGamesSdk.IsInitialized == false)
        {
            yield return YandexGamesSdk.Initialize();
        }

        YandexGamesSdk.CallbackLogging = true;
#endif

            //GameAnalytics.Initialize();
            SceneManager.LoadScene(_nameScene);
        }
    }
}
