using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float xSpawn = 9.9f;
    public float ySpawn = 0.593475f;
    public float zSpawn = 25;
    public float tileLength = 100;
    public int numberOfTiles = 2;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();


    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i==0)
            {
                SpawnTile(0);
            }else
            {
                SpawnTile(Random.Range(0,tilePrefabs.Length)); 
            }
        }

    }

    void Update()
    {
        if (playerTransform.position.z - 110 >zSpawn - (numberOfTiles*tileLength))
        {
            SpawnTile(Random.Range(0,tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile (int tileIndex) {
        GameObject go = Instantiate(tilePrefabs[tileIndex], new Vector3(xSpawn, ySpawn, zSpawn), transform.rotation);
        activeTiles.Add(go);
        zSpawn+=tileLength;
    }
    private void DeleteTile () {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
