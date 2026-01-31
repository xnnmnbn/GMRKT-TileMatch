using UnityEngine;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour {
    [SerializeField] private Camera mainCamera;
    [SerializeField] private float minSwipeDistance = 0.25f;
    [SerializeField] private LevelLoader loader;

    [SerializeField] private Text debugText;

    private Vector2 touchStartWorld;
    private Vector2 touchEndWorld;

    private int rows;
    private int cols;
    private int nearestIndex;

    private Vector3[] gridPositions;

    public Swipe CurrentSwipe;

    private void Start() {
        gridPositions = loader.Positions;
        CurrentSwipe = default;

        LevelDescriptor ld = loader.descriptors[loader.CurrentLevel];
        rows = ld.rows;
        cols = ld.cols;
    }

    private void Update() {
        if (Input.touchCount == 0) return;

        if (gridPositions.Length == 0) {
            gridPositions = loader.Positions;
            Debug.Log("Attempted to attach positions.");
            return;
        }

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began) {
            touchStartWorld = mainCamera.ScreenToWorldPoint(touch.position);
            nearestIndex = FindNearestGridIndex(touchStartWorld);
        }

        if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
            touchEndWorld = mainCamera.ScreenToWorldPoint(touch.position);
            DetectSwipe();
            Debug.Log(CurrentSwipe);
        }

        debugText.text = CurrentSwipe.ToString();
    }

    private void DetectSwipe() {
        Vector2 delta = touchEndWorld - touchStartWorld;

        if (delta.magnitude < minSwipeDistance) {
            CurrentSwipe = new Swipe(Direction.None, 0, -1, false);
            return;
        }

        int row = nearestIndex / cols;
        int col = nearestIndex % cols;

        Debug.Log(touchStartWorld);

        if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y)) {
            int w = (delta.x > 0) ? 1 : -1;
            CurrentSwipe = new Swipe(Direction.Row, w, row, true);

            return;
        }

        int way = (delta.y > 0) ? 1 : -1;
        CurrentSwipe = new Swipe(Direction.Col, way, col, true);
    }

    private int FindNearestGridIndex(Vector2 worldPos) {
        float minDistSq = float.MaxValue;
        int nearest = 0;

        for (int i = 0; i < gridPositions.Length; i++) {
            float d = (gridPositions[i] - (Vector3)worldPos).sqrMagnitude;
            if (d < minDistSq) {
                minDistSq = d;
                nearest = i;
            }
        }

        return nearest;
    }
}
