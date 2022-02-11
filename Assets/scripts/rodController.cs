using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rodController : MonoBehaviour
{
    public float offsetx;
    public float offsety;

    public GameObject hook;
    public GameObject canvas;
    GameObject child;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = new Vector2(Input.mousePosition.x - offsetx, Input.mousePosition.y - offsety);

        if (Input.GetMouseButtonDown(0))
        {
            Destroy(child);
            child = Instantiate(hook, Input.mousePosition, transform.rotation);
            child.transform.SetParent(canvas.transform);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(child);
        }
    }
}
