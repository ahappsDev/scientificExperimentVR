using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [Header("Settings Enemy Attack")]
    public float rangeBodyToBody = 1.7f;
    public float attackSpeed = .01f;

    private Transform _playerTransform;
    private Transform _transform;

    private Vector3 _directionToPlayer;

    private Animator _animator;

    // Start is called before the first frame update
    void Awake()
    {
        _transform = GetComponent<Transform>();
        _playerTransform = Player.instance.transform;
        
        _animator = GetComponent<Animator>();
    }

    void Start()
    {
        StartCoroutine(CheckAttack());
    }

    private IEnumerator CheckAttack()
    {
        yield return null;
        while (true)
        {
            _directionToPlayer = _playerTransform.position - _transform.position;
            var distanceToPlayer = _directionToPlayer.magnitude;
            if (distanceToPlayer <= rangeBodyToBody && gameObject.GetComponent<Health>().IsAlive)
            {
                _animator.SetTrigger("Punch");
                yield return new WaitForSeconds(attackSpeed);
            }
            else
            {
                yield return null;
            }
        }
    }
}
