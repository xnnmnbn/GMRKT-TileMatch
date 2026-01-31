using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {
    public int CurrentLevel { get; private set; }
    public float GridSize { get; private set; }
    [SerializeField] private TilePools pools;
    [SerializeField] private Transform board;
    [SerializeField] private RectTransform levelButtonsRT;
    public LevelDescriptor[] descriptors;

    public Transform[] AcquiredTransforms;
    public Vector3[] Positions;

    private void Start() {
        foreach (Transform child in levelButtonsRT) {
            GameObject o = child.gameObject;

            string[] words = o.name.Split('_');

            if (words.Length != 3) continue;

            int idx = int.Parse(words[2]) - 1;

            Debug.Log(idx);

            o
            .GetComponent<Button>()
            .onClick
            .AddListener(
                () => LoadLevel(idx)
            );
        }
    }


    public void LoadLevel(int idx) {
        CurrentLevel = idx;
        levelButtonsRT.anchoredPosition += new Vector2(1000, 0);

        int rows = descriptors[idx].rows;
        int cols = descriptors[idx].cols;
        AcquiredTransforms = new Transform[rows * cols];
        Positions = GeneratePositions(rows, cols);
        board.position = Vector3.zero;
        board.localScale = new Vector3(rows, cols);

        SpawnTiles(rows, cols);
    }

    private void SpawnTiles(int rows, int cols) {
        TileColor[] colors = new TileColor[] { TileColor.Red, TileColor.Green, TileColor.Blue, TileColor.Yellow };

        for (int i = 0; i < Positions.Length; i++)
        {
            TileColor color = colors[Random.Range(0, colors.Length)];
            Transform t = pools.AcquireNextTileTransform(color);
            t.position = transform.position + Positions[i];
            AcquiredTransforms[i] = t;
        }
    }

    private Vector3[] GeneratePositions(int rows, int cols) {
        Vector3[] positions = new Vector3[cols * rows];

        float startX = -(rows - 1) * 0.5f;
        float startY =  (cols - 1) * 0.5f;

        int index = 0;

        for (int y = 0; y < cols; y++)
        {
            for (int x = 0; x < rows; x++)
            {
                positions[index++] = new Vector3(
                    startX + x,
                    startY - y,
                    0f
                );
            }
        }

        return positions;
    }
}






