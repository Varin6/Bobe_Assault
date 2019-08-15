using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource;
    //static MusicPlayer instance;

    private void Awake()
    {
        int numMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;

        if (numMusicPlayer > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

//        if (instance == null)
//        {
//            instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else if (instance != this)
//        {
//            Destroy(gameObject);
//        }
//        _audioSource = GetComponent<AudioSource>();
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
//        PlayMusic();
    }


//    public void PlayMusic()
//    {
//        if (_audioSource.isPlaying) return;
//        _audioSource.Play();
//    }

}
