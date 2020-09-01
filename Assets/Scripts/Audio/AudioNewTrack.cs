using UnityEngine;

public class AudioNewTrack : MonoBehaviour
{
    private AudioManager manager;
    public int newTrackID;
    public bool playOnStart;

    void Start()
    {
        manager = FindObjectOfType<AudioManager>();
        if (playOnStart)
            manager.PlayeNewTrack(newTrackID);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager.PlayeNewTrack(newTrackID);
            gameObject.SetActive(false);
        }
    }
}
