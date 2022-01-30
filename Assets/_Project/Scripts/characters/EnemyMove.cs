using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    public float rangeMove = 1.5f;
    public float sightMove = 15f;
    protected Transform _playerTransform;
    protected Transform _transform;
    private Vector3 _directionToPlayer;
    NavMeshAgent nav;
    private Animator _animator;

    public void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        _playerTransform = Player.instance.transform; 
        _transform = gameObject.GetComponent<Transform>();
        _animator = GetComponent<Animator>();
    }

    public void Start()
    {
        nav.enabled = true;
    }

    public void Update()
    {
        _directionToPlayer = _playerTransform.position - _transform.position;
        var distanceToPlayer = _directionToPlayer.magnitude;

        nav.destination = _playerTransform.position;
        //If view target
        if (distanceToPlayer <= sightMove && gameObject.GetComponent<Health>().IsAlive)
        {
            _animator.SetBool("Run", true);
            nav.Resume();

            //Stop velocity if is dead
            if (!gameObject.GetComponent<Health>().IsAlive)
            {
                nav.Stop();
                nav.velocity = new Vector3(0, 0, 0);
            }
        }
        else
        {
            _animator.SetBool("Run", false);
            nav.Stop();
            nav.velocity = new Vector3(0, 0, 0);
        }
    }
}
