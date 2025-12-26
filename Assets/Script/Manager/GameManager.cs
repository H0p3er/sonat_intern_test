using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

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

    public SceneName currentScene;

}
