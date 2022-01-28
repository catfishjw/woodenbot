using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicKeys : MonoBehaviour
{
    public KeyCode keyToPress;
    public Collider Collider;

    public Material defaultMaterial;
    public Material pressedMaterial;
    Renderer textureChanger;
    // Start is called before the first frame update
    void Start()
    {
        Renderer textureChanger = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            StartCoroutine(CollisionToggle());
        }
    }
    public IEnumerator CollisionToggle()
    {
        Renderer textureChanger = gameObject.GetComponent<Renderer>();
        Collider.enabled = true;
        textureChanger.material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.05f);
        textureChanger.material.SetColor("_Color", Color.blue);
        Collider.enabled = false;

    }
}

