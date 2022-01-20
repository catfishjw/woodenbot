using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishingController : MonoBehaviour
{
    public string[] buzzwords;
    public int[] fishValues;
    public int timer;

    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    public GameObject myPrefab;
    public GameObject canvasObject;

    public bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (!running)
        {
            CancelInvoke();
        }
    }

    void Spawn()
    {
        // Instantiate a random prefab
        int spawnX = Random.Range(-69, 600);
        int spawnY = Random.Range(0, 560);
        GameObject childObject = Instantiate(myPrefab, new Vector3(spawnX, spawnY, 0), transform.rotation) as GameObject;
        childObject.transform.parent = canvasObject.transform;
    }
}