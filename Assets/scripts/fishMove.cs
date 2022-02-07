using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fishMove : MonoBehaviour
{
    public fishingController fishingController;
    public Canvas fishingCanvas;

    private RectTransform phishT;
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

    void Start()
    {
        phishT = GetComponent<RectTransform>();
        phishR = GetComponent<Rigidbody>();
        canvasT = fishingCanvas.GetComponent<RectTransform>();
        Vector3[] corners = new Vector3[4];
        canvasT.GetWorldCorners(corners);
        screenRect = new Rect(corners[0].x, corners[0].y, canvasT.rect.width, canvasT.rect.height);
        force = Random.Range(10, 20);
        max = Random.Range(10, 35);
    }

    void Update()
    {
        durationBounce = Time.time - lastBounce;
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
        float x = Random.Range(.75f,1);
        float y = Random.Range(.75f,1);
        float temp = 2;
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
        //orginVelocity.Normalize();
        phishR.AddForce(orginVelocity, ForceMode.Impulse);
    }
}