using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fishMove : MonoBehaviour
{
    public fishingController fishingController;

    private RectTransform phishT;
    private Rigidbody phishR;

    float forcex;
    float forcey;

    float changetime = 1f;
    float duration;
    float lastMove;

    Rect screenRect;
    bool onScreen;

    void Start()
    {
        phishT = GetComponent<RectTransform>();
        phishR = GetComponent<Rigidbody>();
        screenRect = new Rect(0f, 0f, Screen.width, Screen.height);
    }

    void Update()
    {
        if (OnScreen())
        {
            duration = Time.time - lastMove;
            if (duration >= changetime)
            {
                forcex = Random.Range(-150, 150);
                forcey = Random.Range(-150, 150);
                phishR.AddForce(new Vector3(1 * forcex, 1 * forcey), ForceMode.Impulse);
                lastMove = Time.time;
            }
        }
        else
        {
            phishR.velocity = -phishR.velocity;
        }
    }

    bool OnScreen()
    {
        Vector3[] corners = new Vector3[4];
        phishT.GetWorldCorners(corners);

        onScreen = true;

        foreach (Vector3 corner in corners)
        {
            if (!screenRect.Contains(corner))
            {
                onScreen = false;
            }
        }
        return onScreen;
    }
}