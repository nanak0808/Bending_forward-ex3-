using UnityEngine;

public class WeightingFruitScore : MonoBehaviour
{
    public float score;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = transform.position.z * 10f;
        score = Mathf.Floor(score);
    }
}
