using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugSightHeight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("height = " + transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
