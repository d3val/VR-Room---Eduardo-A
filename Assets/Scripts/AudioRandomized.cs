using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomized : MonoBehaviour
{
    [SerializeField] AudioClip[] audioClips;
    private AudioClip lastAudioClip;
    [SerializeField] AudioSource[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(GenerateSound), 3, 10);
    }

    private void GenerateSound()
    {
        int Index = Random.Range(0, audioSources.Length);

        AudioClip RandomClip = audioClips[Random.Range(0, audioClips.Length)];
        while (RandomClip == lastAudioClip)
        {
            RandomClip = audioClips[Random.Range(0, audioClips.Length)];
        }
        audioSources[Index].PlayOneShot(RandomClip);
        lastAudioClip = RandomClip;
    }

    
}
