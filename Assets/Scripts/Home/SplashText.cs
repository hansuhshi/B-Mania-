using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
  
public class SplashText : MonoBehaviour
{
    public string[] splashText;
    public GameObject TextDisplay;
 
    void Start () // Random message on main menu
    {
       TextDisplay.GetComponent<Text>().text = GetRandomSplashText();
    }
 
    string GetRandomSplashText ()
    {
        // Gets a random number between 0 and the number of strings in the array
        int random = Random.Range(0, splashText.Length);
        // Returns the index random from the string array
        return splashText[random];
    }
}