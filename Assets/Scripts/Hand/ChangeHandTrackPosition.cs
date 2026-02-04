using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHandTrackPosition : MonoBehaviour
{
    [SerializeField] public float expansion_rate = 1;
    [SerializeField] private Transform TrackingSpace;
    [SerializeField] private Transform TrackHand;
    [SerializeField] private float HandStartPosition = 0;   //予め、長座体前屈装置に手を置いた時の手のz座標の初期位置を求めておいて設定
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ChangeHandPosition();
    }

    void ChangeHandPosition()
    {
        Vector3 handPosition = GetHandGlobalPosition();
        float diff = handPosition.z - HandStartPosition;
        float exDiff = diff * expansion_rate;

        handPosition.z = HandStartPosition + exDiff;
        transform.position = handPosition;
    }

    public Vector3 GetHandGlobalPosition()
    {
        // OVRHandsの位置データを取得
        return TrackHand.position;
    }
}
