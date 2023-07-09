using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SongItemDisplay : MonoBehaviour
{
    public Text textName;
    public Text textLevel;
    public Text textArtitst;
    public Image sprite;

    public delegate void SongItemDisplayDelegate(SongItem item);
    public event SongItemDisplayDelegate onClick;

    public SongItem item;

    public SongManager songManager;

    Player player;

    // If you don't use static the event remembers all the variable values so if you've pressed it once before the scene doesn't change even if you press another button once
    static string songCheck = "";
    static int clickCnt = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (item != null) Prime(item);

        songManager = GameObject.Find("SongSelect").GetComponent<SongManager>();

        player = FindObjectOfType<Player>();
    }

    public void Prime(SongItem item)
    {
        this.item = item;
        if (textName != null)
            textName.text = item.songName;
        if (textLevel != null)
            textLevel.text = item.songLevel;
        if (textArtitst != null)
            textArtitst.text = item.songArtist;
        if (sprite != null)
            sprite.sprite = item.sprite;
    }

    public void Click()
    {
        if (onClick != null)
            onClick.Invoke(item);
        else
        {
            if (songCheck.Equals(item.songName))
                clickCnt++;
            else
            {
                clickCnt = 0;
                songCheck = item.songName;
                clickCnt++;
            }

            Debug.Log(item.songName);
            // Preview the song
            songManager.PlayAudioPreview(item.songName);


            // Play scene conversion and song data to be transmitted
            if (clickCnt.Equals(2))
            {
                songManager.SelectSong(item.songName);
                clickCnt = 0; // Make sure ESC works properly
                if (!player.isEditMode)
                    SceneManager.LoadSceneAsync("Play");
            }
        }
    }
}
