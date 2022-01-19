using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Pit : MonoBehaviour
{
    [SerializeField] private Transform transformPlayer;
    [SerializeField] private Volume fadeToBlackVolume;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            DOTween.To(() => fadeToBlackVolume.weight, x => fadeToBlackVolume.weight = x, 1f, 1).OnComplete(() =>
            {
                transformPlayer.position = new Vector3(0, 0, 0);

                DOTween.To(() => fadeToBlackVolume.weight, x => fadeToBlackVolume.weight = x, 0f, 1);
            });
        }
    }
}
