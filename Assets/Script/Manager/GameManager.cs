using UnityEditor.Experimental.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public SceneName currentScene;

    public GameState gameState;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
        };

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    public enum SceneName
    {
        Scene_Gameplay,
        Scene_MainMenu,
    }

    public enum GameState
    {
        Playing,
        Pause,
        Win,
        Lose,
    }

}
