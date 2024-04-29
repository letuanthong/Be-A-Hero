using UnityEngine;
using System.Collections;

public class AudioController: MonoBehaviour
{
    [Header("Audio Source")]
    [SerializeField] private AudioSource audioMusic;

    [Header("Audio Clip")]
    [SerializeField] private AudioClip backGround;

    private void Start()
    {
        audioMusic.clip = backGround;
        audioMusic.Play();
    }
}

