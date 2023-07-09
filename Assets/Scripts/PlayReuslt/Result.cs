using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System;
using UnityEngine.SceneManagement;

public class Result : MonoBehaviour
{
    Score score;
    Sheet sheet;

    Image spriteSongImg;
    Text textSongName;
    Text textSongSheet;
    Text textSongLevel;
    Text textSongJudge;
    Text textSongCombo;
    Text textSongScore;

    void Start() // Getting all the stats
    {
        score = GameObject.Find("Score").GetComponent<Score>();
        sheet = GameObject.Find("Sheet").GetComponent<Sheet>();
        spriteSongImg = GameObject.Find("SongImg").GetComponent<Image>();
        textSongName = GameObject.Find("SongName").GetComponent<Text>();
        textSongSheet = GameObject.Find("SongSheet").GetComponent<Text>();
        textSongLevel = GameObject.Find("SongLevel").GetComponent<Text>();
        textSongJudge = GameObject.Find("SongJudge").GetComponent<Text>();
        textSongCombo = GameObject.Find("SongCombo").GetComponent<Text>();
        textSongScore = GameObject.Find("SongScore").GetComponent<Text>();
        spriteSongImg.sprite = Resources.Load<Sprite>(sheet.Title + "/" + sheet.ImageFileName) as Sprite;
        textSongName.text = sheet.Title;
        textSongSheet.text = "sheet by " + sheet.SheetBy;
        textSongLevel.text = sheet.Difficult;

        // Showing all the stats
        StringBuilder judge = new StringBuilder();
        judge.Append("GREAT   ");
        judge.Append(score.GreatCnt.ToString());
        judge.Append("\n");
        judge.Append("GOOD    ");
        judge.Append(score.GoodCnt.ToString());
        judge.Append("\n");
        judge.Append("MISS       ");
        judge.Append(score.MissCnt.ToString());
        textSongJudge.text = judge.ToString();

        textSongCombo.text = "MAX Combo  " + score.MaxCombo.ToString();
        textSongScore.text = "score   " + score.SongScore.ToString();

    }

    void Update() // Bring back to song select after esc
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            SelectSong();
        }
    }


    void SelectSong()
    {
        GameObject sheet = GameObject.Find("Sheet");
        GameObject score = GameObject.Find("Score");
        GameObject songSelect = GameObject.Find("SongSelect");
        Destroy(sheet);
        Destroy(score);
        Destroy(songSelect);

        SceneManager.LoadScene("SongSelect");
    }

}
