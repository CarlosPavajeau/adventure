using UnityEngine;

namespace Audio
{
    public class AudioVolumeManager : MonoBehaviour
    {
        private AudioVolumeController[] audios;
        public float maxVolumeLevel;
        public float currentVolumeLevel;

        // Start is called before the first frame update
        void Start()
        {
            audios = FindObjectsOfType<AudioVolumeController>();
            ChangeGlobalAudioVolume();
        }

        public void ChangeGlobalAudioVolume()
        {
            if (currentVolumeLevel >= maxVolumeLevel)
                currentVolumeLevel = maxVolumeLevel;

            foreach (AudioVolumeController audioVolume in audios)
                audioVolume.SetAudioLevel(currentVolumeLevel);
        }
    }
}
