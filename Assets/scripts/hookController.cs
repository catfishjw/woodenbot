using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = GameObject.Find("cursor").GetComponent<Transform>().position - gameObject.GetComponent<Transform>().position;

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        Vector3 targetPosition = new Vector3(transform.position.x + (GameObject.Find("cursor").GetComponent<Transform>().position.x - gameObject.GetComponent<Transform>().position.x), transform.position.y + (GameObject.Find("cursor").GetComponent<Transform>().position.y - gameObject.GetComponent<Transform>().position.y), transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, .01f);
    }
}
