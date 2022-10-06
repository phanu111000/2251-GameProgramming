using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource _jump, _walk, _sprung, _diamond, _win, _die;

    public void PlayerJump()
    {
        _jump.Play();
    }

    public void PlayerWalk()
    {
        _walk.Play();
    }

    public void Sprung()
    {
        _sprung.Play();
    }

    public void Diamond()
    {
        _diamond.Play();
    }

    public void Win()
    {
        _win.Play();
    }

    public void Die()
    {
        _die.Play();
    }
}