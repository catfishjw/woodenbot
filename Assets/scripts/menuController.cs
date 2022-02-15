using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{
    public GameObject fishRules;
    public GameObject beatRules;
    public GameObject menuCanvas;

    void OnEnable()
    {
        menuCanvas.SetActive(true);
        beatRules.SetActive(false);
        fishRules.SetActive(false);
    }

    public void Fish()
    {
        menuCanvas.SetActive(false);
        fishRules.SetActive(true);
    }

    public void Beat()
    {
        menuCanvas.SetActive(false);
        beatRules.SetActive(true);
    }
}
