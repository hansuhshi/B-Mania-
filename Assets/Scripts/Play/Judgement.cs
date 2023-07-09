using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgement : MonoBehaviour
{
    Sheet sheet;
    Score score;
    SongManager songManager;

    float currentTime;// Current music sample value

    float currentNoteTime1;
    float currentNoteTime2;
    float currentNoteTime3;
    float currentNoteTime4;

    // Judgment (based on frequency value)
    float greatRate = 3025f;
    float goodRate = 7050f;
    float missRate = 16100f;

    int laneNum;

    Queue<float> judgeLane1 = new Queue<float>();
    Queue<float> judgeLane2 = new Queue<float>();
    Queue<float> judgeLane3 = new Queue<float>();
    Queue<float> judgeLane4 = new Queue<float>();

    void Start()
    {
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        SetQueue();
        songManager = GameObject.Find("SongSelect").GetComponent<SongManager>();
        score = GameObject.Find("Score").GetComponent<Score>();
    }

    void Update()
    {
        // Judgement input (keep checking in loop)
        currentTime = songManager.music.timeSamples;

        // Misjudgement (when the judgment line is crossed)
        // Lane 1. Convert the note time received from the queue to a sample
        if (judgeLane1.Count > 0) // Do not run if there is no more data in the queue
        {
            currentNoteTime1 = judgeLane1.Peek(); // Converts the current note time value to PCM sample value without pulling out the data
            currentNoteTime1 = currentNoteTime1 * 0.001f * songManager.music.clip.frequency;
            //When the time value of the note is 1000 (1 second), the PCM value of 44100 comes out

            if (currentNoteTime1 + missRate <= currentTime)
            // 44100 + 16100 <= currentTime (the location of the current music playback)
            // = 1sec + 0.36 sec
            {
                judgeLane1.Dequeue();
                score.ProcessScore(0);
            }
        }
        
        // Lane 2
        if (judgeLane2.Count > 0)
        {
            currentNoteTime2 = judgeLane2.Peek();
            currentNoteTime2 = currentNoteTime2 * 0.001f * songManager.music.clip.frequency;

            if (currentNoteTime2 + missRate <= currentTime)
            {
                judgeLane2.Dequeue();
                score.ProcessScore(0);
            }
        }

        // Lane 3
        if (judgeLane3.Count > 0)
        {
            currentNoteTime3 = judgeLane3.Peek();
            currentNoteTime3 = currentNoteTime3 * 0.001f * songManager.music.clip.frequency;

            if (currentNoteTime3 + missRate <= currentTime)
            {
                judgeLane3.Dequeue();
                score.ProcessScore(0);
            }
        }

        // Lane 4
        if (judgeLane4.Count > 0)
        {
            currentNoteTime4 = judgeLane4.Peek();
            currentNoteTime4 = currentNoteTime4 * 0.001f * songManager.music.clip.frequency;

            if (currentNoteTime4 + missRate <= currentTime)
            {
                judgeLane4.Dequeue();
                score.ProcessScore(0);
            }
        }
    }

    public void JudgeNote(int laneNum)
    {
        this.laneNum = laneNum;
        // If the current note time is greater or less than the judgement range calculated from the current time, the part is judged
        if (laneNum.Equals(1))
        {
            // Note checking range
            if (currentNoteTime1 > currentTime - missRate && currentNoteTime1 < currentTime + missRate)
            {
                if (currentNoteTime1 > currentTime - goodRate && currentNoteTime1 < currentTime + goodRate)
                {
                    // Great judgement +- 0.15s
                    if (currentNoteTime1 > currentTime - greatRate && currentNoteTime1 < currentTime + greatRate)
                    {
                        judgeLane1.Dequeue();
                        score.ProcessScore(2);
                    }
                    // Good judgement +- 0.06 s
                    else
                    {
                        judgeLane1.Dequeue();
                        score.ProcessScore(1);
                    }
                }
                // Miss (when you type too fast)
                else
                {
                    judgeLane1.Dequeue();
                    score.ProcessScore(0);
                }
            }
        }
        if (laneNum.Equals(2))
        {
            if (currentNoteTime2 > currentTime - missRate && currentNoteTime2 < currentTime + missRate)
            {
                if (currentNoteTime2 > currentTime - goodRate && currentNoteTime2 < currentTime + goodRate)
                {
                    // Great Judgement
                    if (currentNoteTime2 > currentTime - greatRate && currentNoteTime2 < currentTime + greatRate)
                    {
                        judgeLane2.Dequeue();
                        score.ProcessScore(2);
                    }
                    // Good judgement
                    else
                    {
                        judgeLane2.Dequeue();
                        score.ProcessScore(1);
                    }
                }
                // Miss (when you type too fast)
                else
                {
                    judgeLane2.Dequeue();
                    score.ProcessScore(0);
                }
            }
        }
        if (laneNum.Equals(3))
        {
            if (currentNoteTime3 > currentTime - missRate && currentNoteTime3 < currentTime + missRate)
            {
                if (currentNoteTime3 > currentTime - goodRate && currentNoteTime3 < currentTime + goodRate)
                {
                    // Great Judgement
                    if (currentNoteTime3 > currentTime - greatRate && currentNoteTime3 < currentTime + greatRate)
                    {
                        judgeLane3.Dequeue();
                        score.ProcessScore(2);
                    }
                    // Good judgement
                    else
                    {
                        judgeLane3.Dequeue();
                        score.ProcessScore(1);
                    }
                }
                // Miss (when you type too fast)
                else
                {
                    judgeLane3.Dequeue();
                    score.ProcessScore(0);
                }
            }
        }
        if (laneNum.Equals(4))
        {
            if (currentNoteTime4 > currentTime - missRate && currentNoteTime4 < currentTime + missRate)
            {
                if (currentNoteTime4 > currentTime - goodRate && currentNoteTime4 < currentTime + goodRate)
                {
                    // Great Judgement
                    if (currentNoteTime4 > currentTime - greatRate && currentNoteTime4 < currentTime + greatRate)
                    {
                        judgeLane4.Dequeue();
                        score.ProcessScore(2);
                    }
                    // Good judgement
                    else
                    {
                        judgeLane4.Dequeue();
                        score.ProcessScore(1);
                    }
                }
                // Miss (when you type too fast)
                else
                {
                    judgeLane4.Dequeue();
                    score.ProcessScore(0);
                }
            }
        }
    }

    // Queue the note times for each lane
    void SetQueue()
    {
        foreach (float noteTime in sheet.noteList1)
            judgeLane1.Enqueue(noteTime);
        foreach (float noteTime in sheet.noteList2)
            judgeLane2.Enqueue(noteTime);
        foreach (float noteTime in sheet.noteList3)
            judgeLane3.Enqueue(noteTime);
        foreach (float noteTime in sheet.noteList4)
            judgeLane4.Enqueue(noteTime);
    }
}