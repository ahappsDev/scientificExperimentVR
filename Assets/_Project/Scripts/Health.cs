using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float timeToDespawn = 5;
    public bool IsAlive => _currentHealth > 0;
    private Animator _animator;
   

    [SerializeField] protected float _currentHealth;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void Update()
    {
    }

    private void OnEnable()
    {
        _currentHealth = maxHealth;
    }

    //Take damage and activate timely animations
    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if (gameObject.CompareTag("Enemy"))
            _animator.SetTrigger("Damage");
        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _animator.SetTrigger("Die");
            StartCoroutine(Die());
        }
    }

    public IEnumerator Die()
    {
        yield return new WaitForSeconds(timeToDespawn);
        this.gameObject.SetActive(false);
    }
}
