using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject current;
    public GameObject cam1;
    public GameObject cam2;

    public 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        current.SetActive(true);
        cam1.SetActive(false);
        cam2.SetActive(false);
    }
}
