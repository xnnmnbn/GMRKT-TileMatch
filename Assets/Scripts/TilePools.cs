using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePools : MonoBehaviour {
    [SerializeField] private GameObject rTile;
    [SerializeField] private GameObject gTile;
    [SerializeField] private GameObject bTile;
    [SerializeField] private GameObject yTile;

    /* * * * * * * * * * * * * * * * * * * *
     * ORDER MATTERS! R, G, B, Y           *
     * DEFAULT VALUES SHOULD START FROM 60 *
     * * * * * * * * * * * * * * * * * * * */

    private int[] _requestedTimesOf = new int[4];

    const int PoolSize = 60;

    public GameObject[] rPool = new GameObject[PoolSize];
    public GameObject[] gPool = new GameObject[PoolSize];
    public GameObject[] bPool = new GameObject[PoolSize];
    public GameObject[] yPool = new GameObject[PoolSize];

    private void Start() {
        Init();
    }

    public Transform AcquireNextTileTransform(TileColor color) {
        int c = (int)color;
        int idx = _requestedTimesOf[c] % PoolSize;

        _requestedTimesOf[c]++;
        

	switch (c) {
            case 0: return rPool[idx].transform;
            case 1: return gPool[idx].transform;
            case 2: return bPool[idx].transform;
            case 3: return yPool[idx].transform;
            default: return null;
        }
    }

    public void Reset() {
        for (int i = 0; i < rPool.Length; i++) {
            rPool[i].transform.position = new Vector3(99, 99, 0);
            gPool[i].transform.position = new Vector3(99, 99, 0);
            bPool[i].transform.position = new Vector3(99, 99, 0);
            yPool[i].transform.position = new Vector3(99, 99, 0);
        }

        for (int i = 0; i < _requestedTimesOf.Length; i++) {
            _requestedTimesOf[i] = 60;
        }
    }


    private void Init() {
        float y = 0;
        _requestedTimesOf[0] = 60;
        _requestedTimesOf[1] = 60;
        _requestedTimesOf[2] = 60;
        _requestedTimesOf[3] = 60;

        for (int i = 0; i < PoolSize; i++) {
            float x = -30;

            rPool[i] = Instantiate(rTile, null);
            rPool[i].transform.position = new Vector3(x, y + i, 0);
            x -= 1;
            
            gPool[i] = Instantiate(gTile, null);
            gPool[i].transform.position = new Vector3(x, y + i, 0);
            x -= 1;

            bPool[i] = Instantiate(bTile, null);
            bPool[i].transform.position = new Vector3(x, y + i, 0);
            x -= 1;

            yPool[i] = Instantiate(yTile, null);
            yPool[i].transform.position = new Vector3(x, y + i, 0);
        }
    }
}






