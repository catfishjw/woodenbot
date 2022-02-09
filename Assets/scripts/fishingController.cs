using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fishingController : MonoBehaviour
{
    public string[] buzzwords;
    public int[] fishValues;
    public int timer;

    public float spawnTime = 5f;
    public float spawnDelay = 3f;
    public TextMeshProUGUI myPrefab;
    public GameObject fishingCanvas;

    private RectTransform canvasT;

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
        TextMeshProUGUI childObject = Instantiate(myPrefab, new Vector3(Random.Range(500,600), Random.Range(500,600), 0), transform.rotation);
        childObject.text = buzzwords[Random.Range(0, buzzwords.Length)];
        childObject.transform.SetParent(fishingCanvas.transform);
        // Instantiate a random prefab
    }

    public void startFishing()
    {
        fishingCanvas.SetActive(true);
    }
}