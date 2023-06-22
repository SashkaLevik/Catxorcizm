﻿using System;
using System.Collections;
using Assets.Sashka.Infastructure;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sashka.Infastructure
{
    public class ScenLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;

        public ScenLoader(ICoroutineRunner coroutineRunner) =>
            _coroutineRunner = coroutineRunner;

        public void Load(string name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

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