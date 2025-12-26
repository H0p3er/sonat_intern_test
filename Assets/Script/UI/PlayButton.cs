using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static GameManager;

public class PlayButton : MonoBehaviour
{
    [SerializeField] Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        if (_button != null) {
            _button.onClick.AddListener(OnClick);
        }      
    }

    private void OnDisable()
    {
        if (_button != null)
        {
            _button.onClick.RemoveListener(OnClick);
        }
    }

    private void OnClick()
    {
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneName.Scene_Gameplay.ToString(), LoadSceneMode.Single);
    }
}
