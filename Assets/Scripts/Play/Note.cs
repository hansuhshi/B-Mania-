using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Note : MonoBehaviour
{
    Player player;

    Sync sync;
    Transform destoryPos;
    Vector3 desPos;

    float speed;
    public int score;

    void Start()
    {
        player = FindObjectOfType<Player>();

        if (!player.isEditMode)
        {
            destoryPos = GameObject.Find("DestroyNote").GetComponent<Transform>();
            desPos = destoryPos.transform.position;
        }

        sync = GameObject.Find("Sync").GetComponent<Sync>();
        speed = sync.scrollSpeed * sync.userSpeedRate;
    }

    void Update()
    {
        StartCoroutine(MoveNote());
    }

    IEnumerator MoveNote() // Move notes down according to beatmap data + sync
    {
        if (transform.position.y > desPos.y)
        {
            transform.Translate(Vector3.down * speed * Time.smoothDeltaTime);
        }
        else
        {
            gameObject.SetActive(false);
        }

        yield return null;
    }

    public void ChangeNoteSpeed(int key) // Altering the position of the notes when increasing and decreasing note speed
    {
        if(key.Equals(0))
        {
            transform.position = new Vector3(transform.position.x , transform.position.y * 1.1f);
            speed *= 1.1f;
            Mathf.Floor(speed);
        }
        else if(key.Equals(1))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y / 1.1f);
            speed /= 1.1f;
            Mathf.Floor(speed);
        }
    }

    public void RotateNote() // Used to check if sync works
    { 
         transform.Rotate(Vector3.back * 45f);
    }
}
