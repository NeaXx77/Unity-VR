using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class TeleportationManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private XRRayInteractor rayInteractor;
    [SerializeField] private TeleportationProvider provider;
    private InputAction thumbstick;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        rayInteractor.enabled = false;

        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Activate");
        activate.Enable();
        activate.performed += OnTeleportActivation;

        var cancel = actionAsset.FindActionMap("XRI LeftHand").FindAction("Teleport Mode Cancel");
        cancel.Enable();
        cancel.performed += OnTeleportationCancel;

        thumbstick = actionAsset.FindActionMap("XRI LeftHand").FindAction("Move");
        thumbstick.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if the teleportation is active and the stick is not triggered to teleport 1 time
        if(!isActive) return;
        if(thumbstick.triggered) return;
        RaycastHit hit;
        if(!rayInteractor.TryGetCurrent3DRaycastHit(out hit)){
            rayInteractor.enabled = false;
            isActive = false;
            return;
        }

        TeleportRequest request = new TeleportRequest(){
            destinationPosition = hit.point
        };
        provider.QueueTeleportRequest(request);
        rayInteractor.enabled = false;
        isActive = false;
    }

    void OnTeleportActivation(InputAction.CallbackContext callback){
        rayInteractor.enabled = true;
        isActive = true;
    }

    void OnTeleportationCancel(InputAction.CallbackContext callback){
        rayInteractor.enabled = false;
        isActive = false;
    }
}
