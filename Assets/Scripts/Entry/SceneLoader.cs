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
