using System.Collections.Generic;
using System.Linq;
using Entry.Views;
using Menu.Controllers;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using Zenject;

namespace Menu.Views
{
    public class MenuView : MonoBehaviour
    {
        [SerializeField]
        private SelectLevelButton selectLevelButtonPrefab;

        [SerializeField]
        private Transform selectLevelButtonsParent;

        [SerializeField]
        private DpadButton startButton;

        [Inject]
        private MenuViewConfig viewConfig;

        [Inject]
        private MenuController menuController;

        [Inject]
        private InputSystemUIInputModule inputModule;

        private readonly Dictionary<SelectLevelButton, int> buttons = new();

        private void Awake()
        {
            menuController.OnCreateSelectLevelButton += CreateSelectLevelButton;
            inputModule.move.action.performed += MoveActionPerformed;

            InitializeStartButton();
        }

        private void InitializeStartButton()
        {
            startButton.Initialize("Start");
            startButton.OnClick += StartButtonClick;
            startButton.SetActive(false);
        }

        private void CreateSelectLevelButton(int level)
        {
            SelectLevelButton button = Instantiate(selectLevelButtonPrefab, selectLevelButtonsParent);
            button.Initialize(level.ToString(), viewConfig.NextColor());
            button.OnClick += SelectLevelClick;

            buttons.Add(button, level);
        }

        private void MoveActionPerformed(InputAction.CallbackContext context)
        {
            if (!context.action.WasReleasedThisFrame())
                return;

            EnsureSelectedLevelButton();
            SelectLevelClick();
        }

        private void StartButtonClick()
        {
            menuController.StartGame();
        }

        private void SelectLevelClick()
        {
            int level = buttons.FirstOrDefault(pair => IsButtonSelected(pair.Key.ButtonGameObject)).Value;

            if (level != 0)
                menuController.SelectLevel(level);

            foreach (KeyValuePair<SelectLevelButton, int> pair in buttons)
                pair.Key.SetSelected(IsButtonSelected(pair.Key.ButtonGameObject));

            startButton.SetActive(level != 0);
        }

        private static bool IsButtonSelected(GameObject buttonGameObject) =>
            buttonGameObject == EventSystem.current.currentSelectedGameObject;

        private void EnsureSelectedLevelButton()
        {
            if (EventSystem.current.currentSelectedGameObject != null)
                return;

            Assert.IsTrue(buttons.Count > 0);

            EventSystem.current.SetSelectedGameObject(buttons.First().Key.ButtonGameObject);
        }

        private void OnDestroy()
        {
            menuController.OnCreateSelectLevelButton -= CreateSelectLevelButton;
            inputModule.move.action.performed -= MoveActionPerformed;
        }
    }
}
