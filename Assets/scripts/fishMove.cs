using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fishMove : MonoBehaviour
{
    public fishingController fishingController;
    public Canvas fishingCanvas;
    public GameObject hook;

    private RectTransform phishT;
    private BoxCollider phishBox;
    private Rigidbody phishR;
    private RectTransform canvasT;

    float forcex;
    float forcey;

    float changetime = 1f;
    float durationRand;
    float durationBounce;
    float bounceGive = 0.1f;
    float lastBounce;
    float lastMove;
    float force;
    float max;

    Rect screenRect;
    int onScreen;

    int cornerNumber;

    public bool bad;

    void Start()
    {
        fishingController = GameObject.Find("fishingController").GetComponent<fishingController>();
        fishingCanvas = GameObject.Find("fish").GetComponent<Canvas>();
        hook = GameObject.Find("hook");
        phishT = GetComponent<RectTransform>();
        phishR = GetComponent<Rigidbody>();
        phishBox = GetComponent<BoxCollider>();
        canvasT = fishingCanvas.GetComponent<RectTransform>();
        Vector3[] corners = new Vector3[4];
        canvasT.GetWorldCorners(corners);
        screenRect = new Rect(corners[0].x, corners[0].y, canvasT.rect.width, canvasT.rect.height);
        force = Random.Range(150, 200);
        max = Random.Range(200, 300);
    }


    void Update()
    {
        durationBounce = Time.time - lastBounce;

        Vector3[] corner = new Vector3[4];
        phishT.GetWorldCorners(corner);
        phishBox.size = new Vector3(corner[3].x - corner[0].x, corner[1].y - corner[0].y, 1);

        if (!(OnScreen() == -1) && durationBounce > bounceGive)
        {
            Bounce(OnScreen());
        }
        else
        {
            durationRand = Time.time - lastMove;
            if (durationRand >= changetime)
            {
                forcex = Random.Range(-force, force);
                forcey = Random.Range(-force, force);
                phishR.AddForce(new Vector3(1 * forcex, 1 * forcey), ForceMode.Impulse);
                lastMove = Time.time;
                changetime = Random.Range(.5f, 2f);
            }
        }
        if(phishR.velocity.magnitude > max)
        {
            phishR.velocity = phishR.velocity.normalized * max;
        }
    }

    int OnScreen()
    {
        Vector3[] corners = new Vector3[4];
        phishT.GetWorldCorners(corners);

        //onScreen = true;
        cornerNumber = 0;

        foreach (Vector3 corner in corners)
        {
            if (!screenRect.Contains(corner))
            {
                if(cornerNumber == 0 && !screenRect.Contains(corners[3]))
                {
                    return 3;
                }
                return cornerNumber;
            }
            cornerNumber++;
        }
        return -1;
    }

    void Bounce(int corner)
    {
        lastBounce = Time.time;
        int x = 1;
        int y = 1;
        float temp = 2.5f;
        float temp2 = 100f;
        Vector3 orginVelocity;
        switch (corner)
        {
            case 0:
                
                orginVelocity = new Vector3(-phishR.velocity.x * x, phishR.velocity.y * y, 0) * temp;
                Bounce2(orginVelocity);
                break;
            case 1:
                orginVelocity = new Vector3(phishR.velocity.x * x, -phishR.velocity.y * y, 0) * temp;
                Bounce2(orginVelocity);
                break;
            case 2:
                orginVelocity = new Vector3(-phishR.velocity.x * x, phishR.velocity.y * y, 0 ) * temp;
                Bounce2(orginVelocity);
                break;
            case 3:
                orginVelocity = new Vector3(phishR.velocity.x * x, -phishR.velocity.y * y, 0 ) * temp;
                Bounce2(orginVelocity);
                break;
            default:
                Debug.Log("bounce default");
                break;
        }
    }

    void Bounce2(Vector3 orginVelocity)
    {
        phishR.AddForce(orginVelocity, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "hook")
        {
            if (bad)
            {
                fishingController.IncreaseScore();
            }
            else
            {
                fishingController.DecreaseLife();
            }

            Destroy(gameObject);
        }
    }
}