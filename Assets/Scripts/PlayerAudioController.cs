using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    [SerializeField] private AudioPlayer audioPlayer;
    
    [Header("Audio Clips")]
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;
    [SerializeField] private SoAudioClips deathAudioClips;

    public ParticleSystem dusty;
    public ParticleSystem impacty;
    public ParticleSystem deady;
    public ParticleSystem winy;
    public ParticleSystem diamondy;

    public void PlayJump()
    {
        audioPlayer.PlaySound(jumpAudioClips, 0.5f);

    }

    public void PlayWalk()
    {
        audioPlayer.PlaySound(walkAudioClips, 0.3f);
        Walk();
    }

    public void PlayFallImpact()
    {
        audioPlayer.PlaySound(walkAudioClips, 0.6f);
        Impact();
    }

    public void PlayDeath()
    {
        audioPlayer.PlaySound(deathAudioClips);
        Dead();
    }
    
    public void MuteAudioSource()
    {
        audioPlayer.MuteAudioSource();
    }

    private void Walk()
    {
        dusty.Play();
        Debug.Log("Dust...");
    }

    private void Impact()
    {
        impacty.Play();
    }

    private void Dead()
    {
        deady.Play();
    }

    public void Win()
    {
        winy.Play();
    }

    public void Diamond()
    {
        diamondy.Play();
    }

    

}
