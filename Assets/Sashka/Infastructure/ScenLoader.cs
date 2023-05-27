using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Sashka.Infastructure
{
    public class ScenLoader
    {
        private readonly ICoroutineRunner _coroutineRanner;

        public ScenLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRanner = coroutineRunner;

        public void Load(string name, Action onLoaded = null) =>
            _coroutineRanner.StartCoroutine(LoadScene(name, onLoaded));

        public IEnumerator LoadScene(string nextScene, Action onLoaded = null)
        {
            if (SceneManager.GetActiveScene().name == nextScene)
            {
                onLoaded?.Invoke();
                yield break;
            }
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(nextScene);

            while (!waitNextScene.isDone)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}