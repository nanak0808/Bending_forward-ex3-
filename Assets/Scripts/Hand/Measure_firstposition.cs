using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Measure_firstposition : MonoBehaviour
{
    [SerializeField] private bool Measure_mode;
    [SerializeField] private Transform TrackingSpace;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Measure_mode) {
            Measure_z_position();
        }
    }

    void Measure_z_position(){
        Vector3 handPosition = GetHandGlobalPosition();
        if (handPosition.z > 0.2) {
            Debug.Log("Hand first position is << " + handPosition.z + " >>");
        }
    }

    public Vector3 GetHandGlobalPosition(){
        // このオブジェクトの位置データを取得
        return transform.position;
    }
}
