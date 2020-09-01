using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioTracks;
    public int currentTrack;
    public bool audioCanBePlay;

    void Update()
    {
        if (audioCanBePlay)
        {
            if (!audioTracks[currentTrack].isPlaying)
                audioTracks[currentTrack].Play();
        }
    }

    public void PlayeNewTrack(int newTrack)
    {
        audioTracks[currentTrack].Stop();
        currentTrack = newTrack;
        audioTracks[currentTrack].Play();
    }
}
