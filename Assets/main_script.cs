using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class main_script : MonoBehaviour
{
    public RawImage rawImg;
    public Animator animator;
    public AudioSource audioSource;

    int current = 0;
    List<string> paths = new List<string>();

    void Start()
    {

        foreach (string file in System.IO.Directory.GetFiles("/Users/briankovo/Desktop/TripPics"))
        {
            if (!file.Contains("DS_Store")) paths.Add(file);
        }

        setImage();
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            current++;
            if (current >= paths.Count) current = 0;
            animator.SetTrigger("change");
        } else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            current--;
            if (current < 0) current = paths.Count - 1;
            animator.SetTrigger("change");
        }
    }

    void setImage() {

        var rawData = System.IO.File.ReadAllBytes(paths[current]);
        Texture2D texture = new Texture2D(2, 2); 
        texture.LoadImage(rawData);
        rawImg.texture = texture;

        Debug.Log("Image loaded.");
    }

    void playAudio() {
        audioSource.Play();
    }
}
