using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchAttack : MonoBehaviour
{
    public int damage = 5;

    private void OnTriggerEnter(Collider other)
    {
        //When the punch hits a target and is active, it takes life.
        if ((other.GetComponent<Enemy>() != null) || (other.GetComponent<Player>() != null) && (gameObject.activeSelf == true))
            other.GetComponent<Health>().TakeDamage(damage);
    }
}
