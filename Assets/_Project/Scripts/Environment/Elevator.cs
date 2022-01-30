using DG.Tweening;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform transformObject;
    [SerializeField] private float height, intPosition;
    [SerializeField] private float timeTranslation;

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

    public void setHeight(float _height)
    {
        height = _height;
    }
}
