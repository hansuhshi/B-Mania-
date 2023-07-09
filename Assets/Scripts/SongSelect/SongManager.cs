using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongManager : MonoBehaviour
{
    public AudioSource music;
    public AudioClip clip;

    public string songName;
    public bool isGameFin;
    public bool isInputESC;

    int previewTime;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();

        previewTime = 30;
    }

    // When the game starts (plays after 3 seconds)
    public void PlayAudioForPlayScene()
    {
        // Starting point
        music.timeSamples = 0;
        music.PlayDelayed(3.0f);
    }

    // Result window when the game is finished
    public void FinishSong()
    {
        isGameFin = music.isPlaying;

        // To stop ESC being pressed after song completes
        if (isGameFin.Equals(false) && isInputESC.Equals(false))
            SceneManager.LoadScene("PlayResult");
    }

    // When it goes over play scene
    public void SelectSong(string songName)
    {
        this.songName = songName;
        music.Stop();
    }

    // When you press ESC while playing
    public void StopSong(bool isInputESC)
    {
        this.isInputESC = isInputESC;

        music.Stop();

    }

    // Preview when a song is selected
    public void PlayAudioPreview(string songName)
    {
        clip = Resources.Load(songName+"/"+songName) as AudioClip;
        music.clip = clip;

        // Preview time original
        music.timeSamples = 0;
        // Preview time adjustment
        music.timeSamples += music.clip.frequency * previewTime;

        music.Play();

    }
}
