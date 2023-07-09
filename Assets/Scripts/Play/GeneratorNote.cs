using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GeneratorNote : MonoBehaviour
{
    Sync sync;
    Transform startPos;
    Sheet sheet;

    public GameObject notePrefab;

    // Note spacing
    float noteCorrectRate = 0.001f; // Correction value for coordinate generation

    // Pre-calculate notes and bars
    float notePosY;
    float noteStartPosY;
    float offset;

    public bool isGenFin = false;
    
    void Start() // Note generation based off beatmap data 
    {
        sync = GameObject.Find("Sync").GetComponent<Sync>();
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        startPos = GameObject.Find("StartPos").GetComponent<Transform>();
        notePosY = sync.scrollSpeed;
        noteStartPosY = sync.scrollSpeed * 3.0f;
        offset = sync.offset;
    }

    void Update()
    {
        if (isGenFin.Equals(false))
        {
            GenNote();
            isGenFin = true;
        }
    }

    // Create notes
    void GenNote()
    {
        foreach(float noteTime in sheet.noteList1)
            Instantiate(notePrefab, new Vector3(2.3f, noteStartPosY + offset +  notePosY * (noteTime * noteCorrectRate)), Quaternion.identity);
        foreach (float noteTime in sheet.noteList2)
            Instantiate(notePrefab, new Vector3(2.96f, noteStartPosY + offset +  notePosY * (noteTime * noteCorrectRate)), Quaternion.identity);
        foreach (float noteTime in sheet.noteList3)
            Instantiate(notePrefab, new Vector3(3.62f, noteStartPosY + offset +  notePosY * (noteTime * noteCorrectRate)), Quaternion.identity);
        foreach (float noteTime in sheet.noteList4)
            Instantiate(notePrefab, new Vector3(4.28f, noteStartPosY + offset +  notePosY * (noteTime * noteCorrectRate)), Quaternion.identity);
    }
}
