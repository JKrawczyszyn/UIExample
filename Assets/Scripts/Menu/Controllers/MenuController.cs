using System;
using Cysharp.Threading.Tasks;
using Entry;
using Entry.Controllers;
using UnityEngine;
using Zenject;

namespace Menu.Controllers
{
    public class MenuController
    {
        public event Action<int> OnCreateSelectLevelButton;

        [Inject]
        private Config config;

        [Inject]
        private GameFlowController gameFlowController;

        private int levelSelected;

        public void Initialize()
        {
            foreach (int level in config.Levels)
                OnCreateSelectLevelButton?.Invoke(level);
        }

        public void StartGame()
        {
            if (levelSelected == 0)
                return;

            Debug.Log($"Start game level '{levelSelected}'.");

            gameFlowController.LoadGame(levelSelected).Forget();
        }

        public void SelectLevel(int level)
        {
            if (level == levelSelected)
                return;

            levelSelected = level;

            Debug.Log($"Select level '{levelSelected}'.");
        }
    }
}
