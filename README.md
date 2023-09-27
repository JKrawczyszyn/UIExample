# UI_zadanie_testowe
**by Jarosław Krawczyszyn**

- Project was created in Unity 2022.3.4f1.
- Start scene is "Entry" scene.
- Configuration as ScriptableObjects are in "Assets/Resources/Configs"
- Menu can be operated by mouse, but also keyboard or gamepad.
- Zenject is used as DI framework.
- Project is split into 3 modules/scenes: "Entry", "Menu", "Game", "GameOver". "Entry" scene is persistent for entire game, "Menu", "Game", "GameOver" scenes are loaded as needed additively. Each scene is in it's own assembly.
- Every scene(except "GameOver" which is only one simple view) has its own entry point which starts controller.
- Almost every aspect of game has it's own view which communicates with injected controllers.
