using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateHandler : MonoBehaviour {
    public LevelState state;
    public LevelDescriptor descriptor;

    void Start() {
        state = LevelState.None;
    }
}
