using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAudioHandler : MonoBehaviour
{
    [SerializeField] private List<AudioClip> _squelches;
    [SerializeField] private AudioSource _squelchSource;
    [SerializeField] private List<AudioClip> _jumps;
    [SerializeField] private AudioSource _jumpSource;
    [SerializeField] private List<AudioClip> _splats;
    [SerializeField] private AudioSource _splatSource;
    [SerializeField] private List<AudioClip> _impacts;
    [SerializeField] private AudioSource _impactSource;
    [SerializeField] private List<AudioClip> _aims;
    [SerializeField] private AudioSource _aimSource;
    [SerializeField] private List<AudioClip> _yippees;
    [SerializeField] private AudioSource _yippeeSource;
    public bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_squelchSource.isPlaying || _jumpSource.isPlaying || _splatSource.isPlaying || _impactSource.isPlaying || _aimSource.isPlaying) isPlaying = true;
        else isPlaying = false;
    }

    public void PlaySquelch()
    {
        var clip = Random.Range(0, _squelches.Count);
        _squelchSource.clip = _squelches[clip];
        _squelchSource.Play();
    }

    public void PlayJump(){
        var clip = Random.Range(0, _jumps.Count);
        _jumpSource.clip = _jumps[clip];
        _jumpSource.Play();
    }


    public void PlaySplat(){
        var clip = Random.Range(0, _splats.Count);
        _splatSource.clip = _splats[clip];
        _splatSource.Play();
    }


    public void PlayImpact(){
        var clip = Random.Range(0, _impacts.Count);
        _impactSource.clip = _impacts[clip];
        _impactSource.Play();
    }


    public void PlayAim(){
        var clip = Random.Range(0, _aims.Count);
        _aimSource.clip = _aims[clip];
        _aimSource.Play();
    }


    public void PlayYippee(){
        var clip = Random.Range(0, _yippees.Count);
        _yippeeSource.clip = _yippees[clip];
        _yippeeSource.Play();
    }
}
