using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAnimation : MonoBehaviour
{
    private PlayerMovement _movement;
    private Animator _animator;

    public float idleCooldownTimer;

    private bool _coroutinePerforming = false;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _movement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        movementDirection direction = _movement.movementDirection;
        switch (direction)
        {
            case movementDirection.Idle:
                if (_coroutinePerforming == false)
                {
                    _animator.Play("Idle");
                }
                _animator.SetBool("Walk Horizontal", false);
                _animator.SetBool("Walk Up", false);

                break;

            case movementDirection.Horizontal:
                _animator.SetBool("Walk Horizontal", true);
                _animator.SetBool("Walk Up", false);

                StopAllCoroutines();
                _coroutinePerforming = false;
    
                break;

            case movementDirection.Up:
                _animator.SetBool("Walk Horizontal", false);
                _animator.SetBool("Walk Up", true);

                StopAllCoroutines();
                _coroutinePerforming = false;

                break;

            case movementDirection.Diagonal:

                break;
        }
    }
    public void ResetIdle()
    {
        _animator.SetBool("Next Idle Animation", false);
    }

    public IEnumerator StartIdleTimer()
    {
        if (_coroutinePerforming == true)
        {
            yield break;
        }
        _coroutinePerforming = true;

        yield return new WaitForSecondsRealtime(idleCooldownTimer);
        _animator.SetBool("Next Idle Animation", true);

        _coroutinePerforming = false;
    }
}
