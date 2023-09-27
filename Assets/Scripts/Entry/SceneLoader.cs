using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Entry
{
    public class SceneLoader
    {
        public async UniTask Load(SceneName name)
        {
            var nameString = name.ToString();

            Debug.Log($"Loading scene '{nameString}'.");

            await SceneManager.LoadSceneAsync(nameString, LoadSceneMode.Additive);
        }

        public async UniTask UnloadAll()
        {
            Debug.Log("Unloading all scenes.");

            foreach (SceneName scene in Enum.GetValues(typeof(SceneName)))
            {
                if (scene == SceneName.None)
                    continue;

                await Unload(scene);
            }
        }

        public async UniTask Unload(SceneName name)
        {
            var nameString = name.ToString();

            Scene scene = SceneManager.GetSceneByName(nameString);

            if (!scene.isLoaded)
                return;

            Debug.Log($"Unloading scene '{nameString}'.");

            await SceneManager.UnloadSceneAsync(nameString);
        }
    }
}
