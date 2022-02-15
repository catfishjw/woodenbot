using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rodController : MonoBehaviour
{
    public float offsetx;
    public float offsety;

    public GameObject hook;
    public GameObject canvas;

    public Transform hookT;

    // Start is called before the first frame update
    void Start()
    {
        hook.SetActive(true);
        hookT = hook.GetComponent< Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = new Vector2(Input.mousePosition.x - offsetx, Input.mousePosition.y - offsety);
    }
}
