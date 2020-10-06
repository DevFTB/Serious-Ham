using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioClip CurrentlyPlaying = null;
    public AudioSource AudioSource;
    public StreakCalculator StreakCalculator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!AudioSource.isPlaying)
        {
            if (CurrentlyPlaying == StreakCalculator.GetCurrentMusic())
            {
                Play(StreakCalculator.GetCurrentMusicLoop());
            }
            else
            {
                Play(StreakCalculator.GetCurrentMusic());
            }
        }
    }

    void Play(AudioClip clip)
    {
        AudioSource.PlayOneShot(clip);
        CurrentlyPlaying = clip;

    }
}
