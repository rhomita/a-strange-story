using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

public class RainSFX : MonoBehaviour
{
    [SerializeField] private List<AudioClip> clips;
    private AudioSource audioSource;

    private float cooldown;
    
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        cooldown = Random.Range(10, 20);
    }

    void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
            return;
        }

        float volume = Random.Range(0.15f, 0.4f);
        audioSource.volume = volume;
        
        cooldown = Random.Range(10, 30);
        int random = Random.Range(0, clips.Count);
        audioSource.PlayOneShot(clips[random]);
    }
}
