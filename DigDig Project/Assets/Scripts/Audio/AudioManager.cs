using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class AudioManager: MonoBehaviour
{
    [Range(0f, 1f)]
    public float globalVolume;

    public GameObject gloablVolumeSlider;
    public GameObject musicVolumeSlider;

    public Sound[] sounds;

    public bool playMusic;
    public float MusicMaxVolume;

    private bool statingSong = false;

   

    public void Start()
    {
        playMusic = true;

        PlaySound("Rain");
      
        StartCoroutine(PlaySoundAtRandom());

        StartCoroutine(PlayMusic());


    }

    public void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.loop = s.loop;
        }
    }

    private void Update()
    {
        globalVolume = gloablVolumeSlider.GetComponent<Slider>().value;
    

        foreach (Sound s in sounds)
        {
            if(!s.dontPauseInMenu)
            {
                if(PauseMenu.pauseMenuActivated) s.source.volume = 0;
                else s.source.volume = s.volume * globalVolume;
            }
            else s.source.volume = s.volume * globalVolume;

            s.source.pitch = s.pitch;


        }

        if (EndScenecut.playingCutscene && playMusic != false)
        {
            playMusic = false;
            StartCoroutine(PlayMusic());
            StartCoroutine(PlaySoundAtRandom());
        }
    }


    public void PlaySound(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);

        float rnd = Random.Range(0, s.clip.Length);
        s.source.clip = s.clip[(int)rnd];

        rnd = Random.Range(0.9f, 1.1f);
        s.pitch = rnd;

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }
 
        s.source.Play();
    }

    IEnumerator PlaySoundAtRandom()
    {
        Sound s = Array.Find(sounds, sound => sound.Name == name);
        float rnd = Random.Range(30, 60);

        foreach (var sound in sounds)
        {
            if (sound.playAtRandom)
            {
                PlaySound(sound.Name);

                yield return new WaitForSeconds(rnd);
            }
        }







        StartCoroutine(PlaySoundAtRandom());
    }

    public IEnumerator PlayMusic()
    {
        Sound s = Array.Find(sounds, sound => sound.Name == "SoundTrack");

        if (playMusic)
        {
            float rnd = Random.Range(40, 80);
            yield return new WaitForSeconds(rnd);

            statingSong = true;

            if (statingSong)
            {
                s.volume = 0;
                PlaySound("SoundTrack");

                while (s.volume <= MusicMaxVolume)
                {
                    s.volume += 0.01f;
                    yield return new WaitForSeconds(0.4f);
                }
            }

            statingSong = false;

            rnd = Random.Range(30, 60);
            yield return new WaitForSeconds(rnd);

            Debug.Log("hit");
            statingSong = true;

            if (statingSong)
            {
                while (s.volume >= 0)
                {
                    s.volume -= 0.01f;
                    yield return new WaitForSeconds(0.4f);
                }

                s.source.Stop();
            }

            statingSong = false;
        }
        else 
        {
            yield return new WaitForSeconds(0);
            s.source.Stop();
        }

        StartCoroutine(PlayMusic());
    }
}
