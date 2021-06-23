using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource[] audioTracks;
        public int currentTrack;
        public bool audioCanBePlay;

        void Update()
        {
            if (!audioCanBePlay)
            {
                return;
            }

            if (!audioTracks[currentTrack].isPlaying)
            {
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
}
