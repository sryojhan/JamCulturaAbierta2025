using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundBoard : Singleton<SoundBoard>
{
    public enum Sound
    {
        Explosion, Gunshot, Laughts
    }

    public AudioClip Explosion;
    public AudioClip Gunshot;
    public AudioClip Laughts;

    private readonly Dictionary<Sound, AudioClip> sounds = new();

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();

        sounds.Add(Sound.Explosion, Explosion);
        sounds.Add(Sound.Gunshot, Gunshot);
        sounds.Add(Sound.Laughts, Laughts);
    }

    public void PlaySound(Sound sound)
    {
        audioSource.PlayOneShot(sounds[sound]);
    }
}
