using UnityEngine;

[System.Serializable]
public struct LevelDescriptor {
    public int rows;
    public int cols;
    
    [Header("Finish Requirements")]
    public byte red;
    public byte green;
    public byte blue;
    public byte yellow;
}