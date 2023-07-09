using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sync : MonoBehaviour
{
    Player player;
    AudioSource music;

    AudioSource playTik;
    public AudioClip tikClip;

    Sheet sheet;
    Note note;
    GeneratorNote generator;

    float musicBPM;
    float stdBPM = 60.0f;
   
    public float oneBeatTime = 0f;
    public float beatPerSample = 0f;

    public float barPerSec = 0f;

    float frequency = 0f;
    float nextSample = 0f;
    
    public float offset; // Music starting point (seconds)
    public float offsetForSample; // Music starting point (sample)

    public float scrollSpeed; //Default speed according to song bpm
    public float userSpeedRate;

    void Start()
    {
        player = FindObjectOfType<Player>();

        playTik = GetComponent<AudioSource>();
        music = FindObjectOfType<SongManager>().GetComponent<AudioSource>();
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        generator = GameObject.Find("GeneratorNote").GetComponent<GeneratorNote>();

        scrollSpeed = 10.0f;
        userSpeedRate = 1f;

        musicBPM = sheet.Bpm;
        frequency = music.clip.frequency;
        offset = sheet.Offset;
        offsetForSample = frequency * offset;
        oneBeatTime = (stdBPM / musicBPM);
        nextSample += offsetForSample;
        barPerSec = oneBeatTime * 4.0f;  
    }

    IEnumerator PlayTik() // For testing sync was working with song
    {   
        if (music.timeSamples >= nextSample)
        {
            playTik.PlayOneShot(tikClip); // Sound playback
            beatPerSample = oneBeatTime * frequency;
            nextSample += beatPerSample;
        }
        yield return null;
    }

}
