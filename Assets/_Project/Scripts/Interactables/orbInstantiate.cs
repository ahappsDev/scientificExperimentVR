using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbInstantiate : MonoBehaviour
{
    [SerializeField] private GameObject orb;
    private float minSpawnDistance = 0.0f;
    private float maxSpawnDistance = 4.5f;
    private Transform _transform;

    void Awake()
    {
        _transform = gameObject.GetComponent<Transform>();
    }

    void Start()
    {
        var randomOffset = Random.insideUnitSphere;

        var offset = new Vector3(randomOffset.x, 0, randomOffset.z).normalized * Random.Range(minSpawnDistance, maxSpawnDistance);
        orb = Instantiate(orb);
        orb.transform.SetParent(_transform);
        orb.transform.position = _transform.position + offset;
    }
}
