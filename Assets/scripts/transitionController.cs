using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class transitionController : MonoBehaviour
{
    public GameObject fishingController;
    public GameObject rhythmController;
    public GameObject menuController;
    public GameObject transitionCanvas;
    public TextMeshProUGUI loadText;

    private float loadTime = 4f;
    public string[] tipText;

    // Start is called before the first frame update
    void Start()
    {
        menuController.SetActive(true);
        fishingController.SetActive(false);
        rhythmController.SetActive(false);
        transitionCanvas.SetActive(false);
    }
    
    public void fishButton()
    {
        Debug.Log("fish");
        StartCoroutine("ToFish");
    }
    
    public void rhythmButton()
    {
        StartCoroutine("ToRhythm");
    }

    public void menuButton()
    {
        StartCoroutine("ToMenu");
    }

    private IEnumerator ToFish()
    {
        menuController.SetActive(false);
        transitionCanvas.SetActive(true);
        SetText();
        yield return new WaitForSeconds(loadTime);
        transitionCanvas.SetActive(false);
        fishingController.SetActive(true);
    }

    private IEnumerator ToRhythm()
    {
        menuController.SetActive(false);
        transitionCanvas.SetActive(true);
        SetText();
        yield return new WaitForSeconds(loadTime);
        transitionCanvas.SetActive(false);
        rhythmController.SetActive(true);
    }

    private IEnumerator ToMenu()
    {
        fishingController.SetActive(false);
        rhythmController.SetActive(false);
        transitionCanvas.SetActive(true);
        SetText();
        yield return new WaitForSeconds(loadTime);
        transitionCanvas.SetActive(false);
        menuController.SetActive(true);
    }

    private void SetText()
    {
        loadText.text = "Cyber tip: " + tipText[Random.Range(0, tipText.Length)];
    }
}
