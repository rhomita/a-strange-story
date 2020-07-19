using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    private AudioSource _audioSource;
    private bool disabled = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        TurnOn();
    }

    public void TurnOn()
    {
        if (disabled) return;
        if (screen.activeSelf) return;
        screen.SetActive(true);
        _audioSource.Play();
    }
    
    public void TurnOff()
    {
        disabled = true;
        screen.SetActive(false);
        _audioSource.Stop();
    }
}
