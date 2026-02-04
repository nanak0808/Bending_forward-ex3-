using UnityEngine;
using System.Collections;

public class SoundHandler : MonoBehaviour
{
    [Header("Target Object")]
    public GameObject targetObject;
    [Header("Audio Clip")]
    public AudioClip[] soundClip;

    private AudioSource audioSource;
    private bool lastState;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        lastState = targetObject.activeSelf;

        PlayBGM(lastState);
    }

    // Update is called once per frame
    void Update()
    {
        bool currentState = targetObject.activeSelf;

        // 状態が変化した場合
        if ( currentState != lastState )
        {
            PlayBGM(currentState);
            lastState = currentState;
        }
    }

    void PlayBGM(bool isActive)
    {
        audioSource.clip = isActive ? soundClip[0] : soundClip[1];
        audioSource.Play();
    }
}
