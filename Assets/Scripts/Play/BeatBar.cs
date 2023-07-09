using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BeatBar : MonoBehaviour
{
    Player player;
    Sheet sheet;
    Sync sync;
    Transform judgebar;
    Vector3 judgePos;

    float speed; // default speed
    public float barCnt; // number of bars

    void Start() // judge bar configuration based on sync.cs + beatmap data file
    {
        player = FindObjectOfType<Player>();

        if (!player.isEditMode)
        {
            judgebar = GameObject.Find("JudgeBar").GetComponent<Transform>();
            judgePos = judgebar.transform.position;
        }
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        sync = GameObject.Find("Sync").GetComponent<Sync>();
        barCnt = sheet.BarCnt;
        speed = sync.scrollSpeed * sync.userSpeedRate;
    }

    void Update()
    {
        StartCoroutine(MoveBeatBar());
    }

    // drop bar configuration based on sync.cs + beatmap data file
    IEnumerator MoveBeatBar()
    {
        if (transform.position.y > judgePos.y)
        {
            transform.Translate(Vector3.down * speed* Time.smoothDeltaTime);
        }
        else
        {
            gameObject.SetActive(false);
        }

        yield return null;
    }
}
