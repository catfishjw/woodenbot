using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicKeys : MonoBehaviour
{
    public KeyCode keyToPress;
    public Collider Collider;

    public Material defaultMaterial;
    public Material pressedMaterial;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            StartCoroutine(collisionToggle());
        }
    }
    public IEnumerator collisionToggle()
    {
        Collider.enabled = true;

        yield return new WaitForSeconds(0.05f);
        Collider.enabled = false;

    }
}

