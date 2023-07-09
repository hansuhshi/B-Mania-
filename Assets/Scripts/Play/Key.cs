using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour//Key Panel
{
    private SpriteRenderer SR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyToPress;

    void Start() // Change the image based on key pressed or not
    {
        SR = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(keyToPress))
        {
            SR.sprite = pressedImage;
        }
        if (Input.GetKeyUp(keyToPress))
        {
            SR.sprite = defaultImage;
        }
    }
}
