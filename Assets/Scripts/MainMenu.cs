using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    [SerializeField] private Button startButtonComponent;
    [SerializeField] private Button exitButtonComponent;

    //[SerializeField] private Button[] levelButtonComponents;
    [SerializeField] private Button backButtonComponent;

    [SerializeField] private RectTransform startButton;
    [SerializeField] private RectTransform exitButton;
    [SerializeField] private RectTransform levelButtonsRT;
    [SerializeField] private RectTransform backButton;

    [SerializeField] private float offscreenDistance = 1000f;
    [SerializeField] private LevelStateHandler levelState;
    [SerializeField] private TilePools pools;
    [SerializeField] private Transform board;

    private void Start() {
        startButtonComponent.onClick.AddListener(OnStartButtonPressed);
        exitButtonComponent.onClick.AddListener(OnExitButtonPressed);
        backButtonComponent.onClick.AddListener(OnBackButtonPressed);
        levelButtonsRT.anchoredPosition += Vector2.right * offscreenDistance;
        backButton.anchoredPosition += Vector2.right * offscreenDistance;
    }

    private void OnStartButtonPressed() {

        startButton.anchoredPosition += Vector2.left * offscreenDistance;
        exitButton.anchoredPosition += Vector2.left * offscreenDistance;
        //levelButtonsRT.anchoredPosition += Vector2.left * offscreenDistance;
        levelButtonsRT.anchoredPosition = Vector2.zero;
        backButton.anchoredPosition += Vector2.left * offscreenDistance;
    }

    private void OnBackButtonPressed() {
        if (levelState.state != LevelState.None) {
            
        }

        pools.Reset();
        board.position = new Vector3(99, 99, 0);

        startButton.anchoredPosition += Vector2.right * offscreenDistance;
        exitButton.anchoredPosition += Vector2.right * offscreenDistance;
        levelButtonsRT.anchoredPosition += Vector2.right * offscreenDistance;
        backButton.anchoredPosition += Vector2.right * offscreenDistance;
    }

    private void OnExitButtonPressed() {
        Application.Quit();
    }

}
