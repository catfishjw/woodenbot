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
    private Vector3[] cornersCan;
    Rect screenRect;

    private RectTransform canvasT;

    public bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
        canvasT = fishingCanvas.GetComponent<RectTransform>();
        cornersCan = new Vector3[4];
        canvasT.GetWorldCorners(cornersCan);
        screenRect = new Rect(cornersCan[0].x + 30, cornersCan[0].y + 30, cornersCan[2].x - cornersCan[0].x - 60, cornersCan[1].y - cornersCan[0].y - 60);
        Debug.Log(cornersCan[0]);
        Debug.Log(cornersCan[1]);
        Debug.Log(cornersCan[2]);
        Debug.Log(cornersCan[3]);
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
        TextMeshProUGUI childObject = Instantiate(myPrefab, Vector3.zero, transform.rotation);
        childObject.text = buzzwords[Random.Range(0, buzzwords.Length)];
        childObject.transform.SetParent(fishingCanvas.transform);
        // Instantiate a random prefab
        bool check = true;
        while (check)
        {
            float spawnX = Random.Range(screenRect.xMin, screenRect.xMax);
            float spawnY = Random.Range(screenRect.yMin, screenRect.yMax);
            childObject.rectTransform.position = new Vector3(spawnX, spawnY, fishingCanvas.transform.position.z);
            Vector3[] corners = new Vector3[4];
            childObject.rectTransform.GetWorldCorners(corners);
            if(screenRect.Contains(corners[0]) && screenRect.Contains(corners[1]) && screenRect.Contains(corners[2]) && screenRect.Contains(corners[3]))
            {
                check = false;
            }
        }
        Debug.Log(childObject.rectTransform.position);
    }

    public void startFishing()
    {
        fishingCanvas.SetActive(true);
    }
}