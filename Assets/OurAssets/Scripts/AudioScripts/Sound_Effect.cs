using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound_Effect
{
	public string name;

	public AudioClip clip;

	[Range(0f, 1f)]
	public float volume;

	[Range(0.1f, 3f)]
	public float pitch;

	[HideInInspector]
	public AudioSource source;

	public bool loop;

	public AudioMixerGroup mixerGroup;

}
