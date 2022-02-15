using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hookController : MonoBehaviour
{

    public GameObject cursor;

    private Transform cursorT;
    private Transform hookT;

    // Start is called before the first frame update
    void Awake()
    {
        cursorT = cursor.GetComponent<Transform>();
        hookT = GetComponent<Transform>();
    }

    void OnEnable()
    {
        hookT.position = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = cursorT.position - hookT.position;

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        Vector3 targetPosition = new Vector3(transform.position.x + (cursorT.position.x - hookT.position.x), transform.position.y + (cursorT.position.y - hookT.position.y), transform.position.z);

        transform.position = Vector3.Lerp(transform.position, targetPosition, .01f);
    }
}
