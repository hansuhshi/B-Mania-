using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    void Start() // Play button
    {

    }

    public void OnClickPlayButton()
    {
        SceneManager.LoadScene("SongSelect");
    }
}
