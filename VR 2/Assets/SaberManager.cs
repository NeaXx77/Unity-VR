using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SaberManager : MonoBehaviour
{
    [SerializeField] GameObject LeftSaber;
    [SerializeField] GameObject RightSaber;
    bool isStarted = false;
    [SerializeField] private InputActionAsset actionAsset;
    InputAction rightHand, leftHand;
    public ActionBasedController controllerRight;
    public ActionBasedController controllerLeft;
    private void Start() {
        rightHand = actionAsset.FindActionMap("XRI RightHand").FindAction("Position");
        leftHand = actionAsset.FindActionMap("XRI LeftHand").FindAction("Position");
        
    }
    private void Update() {
        isStarted = UIManager.instance.isGameStarted;
        if(isStarted){
            controllerLeft.model = LeftSaber.transform;
            controllerRight.model = RightSaber.transform;
            LeftSaber.SetActive(true);
            RightSaber.SetActive(true);
        }else
        {
            controllerLeft.model = null;
            controllerRight.model = null;
            LeftSaber.SetActive(false);
            RightSaber.SetActive(false);
        }
    }

    public void SetIsStarted(bool value){
        isStarted = value;
    }
}
