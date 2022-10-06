using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float jumpPadForce = 13f;
    [SerializeField] private float additionalSleepJumpTime = 0.3f;
    
    private static readonly int Bounce = Animator.StringToHash("Bounce");
    private AudioManager _audioManager;

    public float GetJumpPadForce() => jumpPadForce;
    public float GetAdditionalSleepJumpTime() => additionalSleepJumpTime;

    
    private void Start()
    {
        _audioManager = FindObjectOfType<AudioManager>();
    }

    public void TriggerJumpPad()
    {
        animator.SetTrigger(Bounce);
        _audioManager.Sprung();
    }
}
