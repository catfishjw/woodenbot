using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class whacker : MonoBehaviour
{
    public KeyCode keyToPress;
    public keywhackController controller;
    private bool spawning = false;
    public bool spawned = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawning)
        {
            StartCoroutine(startSpawn);
            spawning = true;
        }
        if (Input.GetKeyDown(keyToPress) && spawned)
        {
            //despawn idk
        }

    }

    public IEnumerator startSpawn()
    {
        int randindex = Random.Range(0, 20);
        yield return new WaitForSeconds(randindex);
        spawned = true;
    }
    public IEnumerator timer()
    {
        int randwait = Random.Range(0, 5);
        yield return new WaitForSeconds(randwait);
    }

}
