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
        screenRect = new Rect(cornersCan[0].x, cornersCan[0].y, canvasT.rect.width, canvasT.rect.height);
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
        childObject.transform.SetParent(fishingCanvas.transform);
        childObject.text = buzzwords[Random.Range(0, buzzwords.Length)];
        // Instantiate a random prefab
        bool check = true;
        while (check)
        {
            float spawnX = Random.Range(cornersCan[0].x, cornersCan[3].x);
            float spawnY = Random.Range(cornersCan[0].y, cornersCan[1].y);
            childObject.rectTransform.position = new Vector3(spawnX, spawnY, fishingCanvas.transform.position.z);
            Vector3[] corners = new Vector3[4];
            childObject.rectTransform.GetWorldCorners(corners);
            foreach (Vector3 corner in corners)
            {
                if (!screenRect.Contains(corner))
                {
                    break;
                }
            }
        }
    }

    public void startFishing()
    {
        fishingCanvas.SetActive(true);
    }
}