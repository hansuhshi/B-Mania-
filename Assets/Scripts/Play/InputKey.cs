using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InputKey : MonoBehaviour
{
    Judgement judgement;
    AudioSource music;
    GameObject[] notes;
    SongManager songManager;

    Text textSpeed;
    int speed = 10;

    Transform d;
    Transform f;
    Transform j;
    Transform k;

    Touch touch;
    Vector3 touchPos;


    // Start is called before the first frame update
    void Start() // Input keys
    {
        judgement = GameObject.Find("Judgement").GetComponent<Judgement>();
        music = GameObject.Find("Music").GetComponent<AudioSource>();
        textSpeed = GameObject.Find("SpeedText").GetComponent<Text>();
        songManager = GameObject.Find("SongSelect").GetComponent<SongManager>();

        d = GameObject.Find("DBtn").GetComponent<Transform>();
        d.gameObject.SetActive(false);
        f = GameObject.Find("FBtn").GetComponent<Transform>();
        f.gameObject.SetActive(false);
        j = GameObject.Find("JBtn").GetComponent<Transform>();
        j.gameObject.SetActive(false);
        k = GameObject.Find("KBtn").GetComponent<Transform>();
        k.gameObject.SetActive(false);


    }

    void Update()
    {
        // D
        if (Input.GetKeyDown(KeyCode.D))
        {
            d.gameObject.SetActive(true);
            judgement.JudgeNote(1);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            d.gameObject.SetActive(false);
        }
        // F
        if (Input.GetKeyDown(KeyCode.F))
        {
            f.gameObject.SetActive(true);
            judgement.JudgeNote(2);
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            f.gameObject.SetActive(false);
        }
        // J
        if (Input.GetKeyDown(KeyCode.J))
        {
            j.gameObject.SetActive(true);
            judgement.JudgeNote(3);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            j.gameObject.SetActive(false);
        }
        // K
        if (Input.GetKeyDown(KeyCode.K))
        {
            k.gameObject.SetActive(true);
            judgement.JudgeNote(4);
        }
        if (Input.GetKeyUp(KeyCode.K))
        {
            k.gameObject.SetActive(false);
        }

        // Change Note Speed
        if (Input.GetKeyDown(KeyCode.F5))
        {
            notes = GameObject.FindGameObjectsWithTag("Note");
            foreach (GameObject note in notes)
                note.GetComponent<Note>().ChangeNoteSpeed(1);
            speed -= 1;
            textSpeed.text = "note speed " + speed.ToString();
        }
        if (Input.GetKeyDown(KeyCode.F6))
        {
            notes = GameObject.FindGameObjectsWithTag("Note");
            foreach (GameObject note in notes)
                note.GetComponent<Note>().ChangeNoteSpeed(0);
            speed += 1;
            textSpeed.text = "note speed " + speed.ToString();
        }
        // Go back
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            songManager.StopSong(true);

            GameObject sheet = GameObject.Find("Sheet");
            GameObject score = GameObject.Find("Score");
            GameObject songSelect = GameObject.Find("SongSelect");
            Destroy(sheet);
            Destroy(score);
            Destroy(songSelect);
            SceneManager.LoadScene("SongSelect");
        }
    }
}