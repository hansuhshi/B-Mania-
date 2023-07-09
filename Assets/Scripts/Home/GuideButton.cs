using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GuideButton : MonoBehaviour
    void Start()
    {

    }

    public void OnClickGuideButton()
    {
        SceneManager.LoadScene("Guide");
    }
}
