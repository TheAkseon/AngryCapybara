using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public static PlayerAnimationController Instance;

    private Animator animator;

    private static readonly string _run = "Run";
    private static readonly string _bossHit = "Boss Hit";
    private static readonly string _hit = "Hit";
    private static readonly string _dance = "Dance";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void BossHit() => animator.SetTrigger(_bossHit);

    public void Hit() => animator.SetTrigger(_hit);

    public void Run() => animator.SetTrigger(_run);

    public void Dance() => animator.SetTrigger(_dance);
}

