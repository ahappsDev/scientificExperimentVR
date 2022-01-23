using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbInstantiate : MonoBehaviour
{
    public GameObject orb;
    private float minSpawnDistance = 0.0f;
    private float maxSpawnDistance = 4.5f;
    private Transform _transform;

    // Start is called before the first frame update
    void Awake()
    {
        _transform = gameObject.GetComponent<Transform>();
        //_transform = gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Start()
    {
        var randomOffset = Random.insideUnitSphere;

        var offset = new Vector3(randomOffset.x, 0, randomOffset.z).normalized * Random.Range(minSpawnDistance, maxSpawnDistance);
        orb = Instantiate(orb);
        orb.transform.SetParent(_transform);
        orb.transform.position = _transform.position + offset;
    }
}
