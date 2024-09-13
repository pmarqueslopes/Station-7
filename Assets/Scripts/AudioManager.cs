using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public bool desativa=true;
    public static AudioManager instance;

   
    void Awake()
    {//manter o AudioManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        //Procurar o Som
        foreach (Sound s in sounds)
        {

            DontDestroyOnLoad(gameObject);

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    public void DesativaAudio(){
        if(desativa){
            desativa=false;
            foreach (Sound s in sounds)
        {
            s.source.volume = 0;
        }
        }
        else{
            desativa=true; 
        
        foreach (Sound s in sounds)
        {
            s.source.volume = 0.2f;
        }
        }
    }

    void Start()
    {//Comecar a musica
        FindObjectOfType<AudioManager>().Play("musicaFundo");
    }

    // Update is called once per frame
    public void Play(string name)
    {//Tocar o Som
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        if (s == null)
        {
            return;
        }
    }
}
//FindObjectOfType<AudioManager>().Play("NomeDoSom");