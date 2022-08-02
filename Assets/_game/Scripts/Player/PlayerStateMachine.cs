using System;
using _game.Scripts.Manager;
using _game.Scripts.Player;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{

    private Animator _animator;
    private static readonly int IsRun = Animator.StringToHash("Run");
    private static readonly int IsIdle = Animator.StringToHash("Idle");
    private static readonly int IsDraw = Animator.StringToHash("Draw");
    private static readonly int IsWin = Animator.StringToHash("Win");

    private void OnEnable()
    {
        GameManager.OnLevelStarted += SetRun;
        GameManager.OnLevelEnd += SetIdle;
    }

    private void OnDisable()
    {
        GameManager.OnLevelStarted -= SetRun;
        GameManager.OnLevelEnd -= SetIdle;
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    void SetRun()
    {
        _animator.SetTrigger(IsRun);
    }
    void SetIdle()
    {
        _animator.SetTrigger(IsIdle);
    }
    void SetDraw()
    {
        _animator.SetTrigger(IsDraw);
    }
    void SetWin()
    {
        _animator.SetTrigger(IsWin);
    }
}
