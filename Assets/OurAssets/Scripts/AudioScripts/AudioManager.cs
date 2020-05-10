
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

	public AudioMixerSnapshot menuMusic;
	public AudioMixerSnapshot gameMusic;

	public Sound_Effect[] soundEffects;

	public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
		if (instance == null) {
			instance = this;
		}
		else {
			Destroy(gameObject);
			return;
		}
		DontDestroyOnLoad(gameObject);

        foreach (Sound_Effect s in soundEffects)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;

			s.source.volume = s.volume;
			s.source.pitch = s.pitch;
			s.source.loop = s.loop;
			s.source.outputAudioMixerGroup = s.mixerGroup;
		}
    }

	private void Start()
	{
		//playSound("GamePlayMusic");
		playSound("MenuMusic");
		Debug.Log("Startmusic");
	}

	public void playSound(string name)
	{

		Sound_Effect s = Array.Find(soundEffects, Sound_Effect => Sound_Effect.name == name);
		if (s == null)
		{
			Debug.LogWarning("Could not find SoundEffect: " +name);
			return;
		}
		s.source.Play(0);

	}

	public void transitionBackgroundMusic(bool result)
	{
		if(result == true)
		{
			playSound("GamePlayMusic");
			this.gameObject.GetComponent<CrossFadeMixers>().CrossfadeGroupsForward(3f);
		}
		else if (result == false)
		{
			this.gameObject.GetComponent<CrossFadeMixers>().CrossfadeGroupsRewind(3f);
		}
		

	}

}
