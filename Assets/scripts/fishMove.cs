using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class fishMove : MonoBehaviour
{
    public fishingController fishingController;

    // Minimum and maximum values for the transition.
    private RectTransform phishT;
    private Rigidbody phishR;
    private IEnumerator coroutine;
    float minimum = 10.0f;
    float maximum = 20.0f;

    float forcex;
    float forcey;

    void Start()
    {
        // Make a note of the time the script started.
        phishT = GetComponent<RectTransform>();
        phishR = GetComponent<Rigidbody>();
        coroutine = Move(.75f);
        StartCoroutine(coroutine);
    }

    private IEnumerator Move(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            forcex = Random.Range(-150, 150);
            forcey = Random.Range(-150, 150);
            phishR.AddForce(new Vector3(1 * forcex, 1 * forcey), ForceMode.Impulse);
            Debug.Log("why");
        }
    }

    void Update()
    {

    }
}
