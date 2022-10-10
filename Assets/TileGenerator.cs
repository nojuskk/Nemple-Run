using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject[] tilePrefabs;

    private int maxTilesOnScreen = 10;
    private float spawnZ = 0;
    private float tileLength = 100f;

    private Transform player;
    private List<GameObject> activeTiles;

	// Use this for initialization
	void Start () {
        activeTiles = new List<GameObject>();
        player = GameObject.Find("Player").transform;
        SpawnTile(0);
        for(int i = 0; i < maxTilesOnScreen - 1; i++)
        {
            SpawnTile();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.position.z -100f > spawnZ - maxTilesOnScreen * tileLength)
        {
            SpawnTile();
            DeleteTile();
        }
	}

    void SpawnTile(int index = -1)
    {
        GameObject go;
        if (index != 0)
        {
            go = Instantiate(tilePrefabs[Random.Range(1, tilePrefabs.Length)]);
        }
        else
        {
            go = Instantiate(tilePrefabs[0]);
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += tileLength;
        activeTiles.Add(go);
    }

    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
