using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Rendering;
using UnityEngine.AI;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float timeToDespawn = 5;
    public bool IsAlive => _currentHealth > 0;
    private Animator _animator;
    private Transform _transform;

    [SerializeField] protected float _currentHealth;
    [SerializeField] protected openDoor _openDoor;
    [SerializeField] private Volume fadeToBlackVolume;

    private NavMeshAgent nav;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _transform = GetComponent<Transform>();

        if (gameObject.CompareTag("Enemy"))
            nav = GetComponent<NavMeshAgent>();
    }

    private void OnEnable()
    {
        _currentHealth = maxHealth;
    }

    //Take damage and activate timely animations
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            if (gameObject.CompareTag("Enemy"))
            {
                _currentHealth = 0;
                _openDoor.open();
                _animator.SetTrigger("Die");
                nav.baseOffset = -0.7f;
            }
            if (gameObject.CompareTag("Player"))
            {
                DOTween.To(() => fadeToBlackVolume.weight, x => fadeToBlackVolume.weight = x, 1f, 1).OnComplete(() =>
                {
                    _transform.position = new Vector3(0, 0, 0);
                    _currentHealth = 20;
                    DOTween.To(() => fadeToBlackVolume.weight, x => fadeToBlackVolume.weight = x, 0f, 1);
                });
            }

        }

        if (gameObject.CompareTag("Enemy") && _currentHealth > 0)
            _animator.SetTrigger("Damage");
    }
}
