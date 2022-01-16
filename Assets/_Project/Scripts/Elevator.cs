using DG.Tweening;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform transformObject;
    public float height, intPosition;
    public float timeTranslation;

    public void Awake()
    {
        intPosition = transformObject.position.y;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            transformObject.DOLocalMoveY(intPosition - height, timeTranslation);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            transformObject.DOLocalMoveY(intPosition, timeTranslation);
        }
    }
}
