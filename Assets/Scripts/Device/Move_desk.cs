using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDevice : MonoBehaviour
{
    [SerializeField] private Transform RightHand;
    private float z_offset = 0.19f;
    [SerializeField] private bool stop = false;
    private Vector3 DevicePosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (stop == true){
            
        } else {
            UpdateDevicePosition();
        }
    }

    void UpdateDevicePosition(){
        // 現在の長座体前屈装置の位置を取得
        DevicePosition = transform.position;
        // 右手のz座標を取得
        Vector3 rightHandPosition = RightHand.position;

        // 右手の位置に合うように装置の位置を代入
        DevicePosition.z = rightHandPosition.z + z_offset;
        // アタッチするオブジェクト（装置）に適用
        transform.position = DevicePosition;
    }
}
