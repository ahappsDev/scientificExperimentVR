using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openDoor : MonoBehaviour
{
    public Transform transformObject;
    public float height;
    public float timeTranslation;
    private AudioSource soundEffect;

    private void Awake()
    {
        soundEffect = GetComponent<AudioSource>();
    }
    public void open()
    {
        transformObject.DOLocalMoveY(transformObject.position.y + height, timeTranslation);
        soundEffect.Play();
    }
}
