using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixer1;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        audioMixer1.SetFloat("volume", volume + 20f);
    }
    /*public void SetPitch(float pitch)
    {
        audioMixer.SetFloat("pitch", pitch);
        audioMixer1.SetFloat("pitch", pitch);
    }*/
}
