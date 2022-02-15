using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class fishingController : MonoBehaviour
{
    public string[] buzzwords;
    public string[] goodwords;
    public int[] fishValues;
    public int timer;
    public int scoreInt;
    public int lifeInt;

    private float spawnTime = 1f;
    private float spawnDelay = .5f;
    public TextMeshProUGUI myPrefab;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI lifeText;
    public GameObject fishingCanvas;
    public GameObject fishingEnd;

    private RectTransform canvasT;

    public bool running = false;

    private byte red = 255;
    private RawImage image;

    // Start is called before the first frame update
    void Start()
    {
        fishingCanvas.SetActive(true);
        InvokeRepeating("Spawn", spawnDelay, spawnTime);
        scoreInt = 0;
        lifeInt = 3;

        scoreText.text = "Score: 0";
        lifeText.text = "Lives: 3";

        Cursor.visible = false;
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
        int rand = Random.Range(1, 6);

        TextMeshProUGUI childObject = Instantiate(myPrefab, new Vector3(Random.Range(400, 1600), Random.Range(400, 600), 0), transform.rotation);

        if (rand != 1)
        {
            childObject.color = new Color32(6, 69, 173, 255);
            childObject.text = buzzwords[Random.Range(0, buzzwords.Length)];
            childObject.GetComponent<fishMove>().bad = true;
        }
        else
        {
            childObject.color = new Color32(0, 0, 0, 255);
            childObject.text = goodwords[Random.Range(0, goodwords.Length)];
            childObject.GetComponent<fishMove>().bad = false;
        }
              
        Vector3[] corners = new Vector3[4];
        childObject.GetComponent<RectTransform>().GetWorldCorners(corners);
        childObject.transform.SetParent(fishingCanvas.transform);
    }

    public void startFishing()
    {
        fishingCanvas.SetActive(true);
    }

    public void IncreaseScore()
    {
        scoreInt++;
        scoreText.text = "Score: " + scoreInt;
    }

    public void DecreaseLife()
    {
        lifeInt--;
        lifeText.text = "Lives: " + lifeInt;
        red -= 40;
        fishingCanvas.GetComponent<RawImage>().color = new Color32(255, red, red, 255);

        if(lifeInt == 0)
        {
            fishingCanvas.SetActive(false);
            fishingEnd.SetActive(true);
            finalScoreText.text = "Score: " + scoreInt;
            Cursor.visible = true;
        }
    }
}