using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorController : MonoBehaviour
{
    public GameObject hook;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update()
    {
            gameObject.transform.position = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            hook.transform.position = Input.mousePosition;
        }
    }
}
