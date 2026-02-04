using UnityEngine;

public class ControlBasket : MonoBehaviour
{
    [SerializeField] private Transform HandObject;
    // [SerializeField] private float z_offset = 0.2f;
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, 0.2f);

    // Update is called once per frame
    void Update()
    {
        UpdateBasketPosition();
    }

    void UpdateBasketPosition(){
        Vector3 handPosition = HandObject.position;
        handPosition += offset;
        transform.position = handPosition;
    }
}
