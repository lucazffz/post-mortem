using System;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using System.Collections;

public class AudioManager: MonoBehaviour
{
    [Range(0f, 1f)]
    public float globalVolume;

    public GameObject slider;

    public Sound[] sounds;

    public void Start()
    {
        PlaySound("Rain");
        PlaySound("SoundTrack");
        StartCoroutine(RandomPlay());
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
        globalVolume = slider.GetComponent<Slider>().value;

        foreach (Sound s in sounds)
        {
            s.source.volume = s.volume * globalVolume;
            s.source.pitch = s.pitch;
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

    IEnumerator RandomPlay()
    {
        float rnd = Random.Range(20, 60);

        yield return new WaitForSeconds(rnd);

        Debug.Log("hit");
        PlaySound("Lightning");

        StartCoroutine(RandomPlay());
    }
}
