using System.Collections;
using System.Collections.Generic;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine;
using UnityEngine.InputSystem;

public class Blower : MonoBehaviour
{
    [SerializeField] private InputActionReference leftTriggerAction;
    [SerializeField] private InputActionReference rightTriggerAction;
    [SerializeField] private AudioSource blowerSoundEffect;
    [SerializeField] private GameObject wint;
    [SerializeField] private Sand sand;
    private ParticleSystem wintParticles;

    private XRGrabInteractable grabInteractable;

    private HandSideType selectingHandSide = HandSideType.None;

    private bool isActivate;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        wintParticles = wint.GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        leftTriggerAction.action.performed += OnTriggerInputLeft;
        rightTriggerAction.action.performed += OnTriggerInputRight;

        grabInteractable.selectEntered.AddListener(GetSelectingHand);
    }

    private void OnDisable()
    {
        leftTriggerAction.action.performed -= OnTriggerInputLeft;
        rightTriggerAction.action.performed -= OnTriggerInputRight;

        grabInteractable.selectEntered.RemoveListener(GetSelectingHand);
    }

    private void activeBlower()
    {
        if(isActivate)
        {
            blowerSoundEffect.Play();
            wintParticles.Play();
            wint.SetActive(true);
        }
        else
        {
            blowerSoundEffect.Stop();
            wintParticles.Stop();
            wint.SetActive(false);
        }
    }

    private void GetSelectingHand(SelectEnterEventArgs arg0)
    {
        selectingHandSide = arg0.interactorObject.transform.GetComponent<HandSide>().handSide;
    }

    #region Input
    private void OnTriggerInputLeft(InputAction.CallbackContext obj)
    {
        if (selectingHandSide != HandSideType.Left)
            return;

        isActivate = !isActivate;
        sand.setIsBlowerActive(isActivate);
        activeBlower();
    }

    private void OnTriggerInputRight(InputAction.CallbackContext obj)
    {
        if (selectingHandSide != HandSideType.Right)
            return;

        isActivate = !isActivate;
        sand.setIsBlowerActive(isActivate);
        activeBlower();
    }
    #endregion
}
