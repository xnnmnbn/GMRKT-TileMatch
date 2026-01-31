using UnityEngine;

public class TileMovementSystem : MonoBehaviour {
    private int rows;
    private int cols;

    private Transform[] tiles;
    private Vector3[] gridPositions;

    [SerializeField] private LevelLoader loader;
    [SerializeField] private SwipeDetector detector;

    private void Update() {
        if (tiles == null) {
            if (loader.AcquiredTransforms != null) {
                tiles = loader.AcquiredTransforms;
            }

            return;
        }

        if (gridPositions == null) {
            Debug.Log("Attempting to acquire positions.");
            gridPositions = loader.Positions;
            return;
        }

        if (rows == 0 || cols == 0) {
            LevelDescriptor ld = loader.descriptors[loader.CurrentLevel];
            rows = ld.rows;
            cols = ld.cols;
            return;
        }

        ApplySwipe(detector.CurrentSwipe);
    }

    /* * * * * * * * * * * * * * * * * *
     * Shift functions should be fixed *
     * * * * * * * * * * * * * * * * * */

    public void ApplySwipe(Swipe swipe) {
        if (!swipe.valid) return;

        if (swipe.dir == Direction.Row) {
            // ShiftRow(swipe.index, swipe.way);
        }
        else if (swipe.dir == Direction.Col) {
            // ShiftColumn(swipe.index, swipe.way);
        }
    }



    private void ShiftRow(int row, int way) {
        Transform[] temp = new Transform[cols];

        for (int x = 0; x < cols; x++) {
            int src = row * cols + x;
            int dstX = Mod(x + way, cols);
            temp[dstX] = tiles[src];
        }

        for (int x = 0; x < cols; x++) {
            int idx = row * cols + x;
            tiles[idx] = temp[x];
            tiles[idx].position = gridPositions[idx];
        }
    }

    private void ShiftColumn(int col, int way) {
        Transform[] temp = new Transform[rows];

        for (int y = 0; y < rows; y++) {
            int src = y * cols + col;
            int dstY = Mod(y + way, rows);
            temp[dstY] = tiles[src];
        }

        for (int y = 0; y < rows; y++) {
            int idx = y * cols + col;
            tiles[idx] = temp[y];
            tiles[idx].position = gridPositions[idx];
        }
    }

    private int Mod(int a, int m) {
        return (a % m + m) % m;
    }
}

