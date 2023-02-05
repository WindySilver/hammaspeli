using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _background;
    [SerializeField] private List<AudioClip> _boss;
    [SerializeField] private List<AudioClip> _death;
    [SerializeField] private List<AudioClip> _suoli;
    [SerializeField] private AudioSource _musicSource;
    public bool suoli = false;
    public bool background = true;
    public bool boss = false;

    // Start is called before the first frame update
    void Start()
    {
        if(background){
            PlayBackground();
        }
        else if (boss){
            PlayBoss();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySuoli()
    {
        var clip = Random.Range(0, _suoli.Count);
        _musicSource.clip = _suoli[clip];
        _musicSource.Play();
    }

    public void PlayBackground()
    {
        var clip = Random.Range(0, _background.Count);
        _musicSource.clip = _background[clip];
        _musicSource.Play();
    }

    public void PlayBoss(){
        var clip = Random.Range(0, _boss.Count);
        _musicSource.clip = _boss[clip];
        _musicSource.Play();
    }


    public void PlayDeath(){
        _musicSource.Stop();
        var clip = Random.Range(0, _death.Count);
        _musicSource.clip = _death[clip];
        _musicSource.Play();
    }

}
