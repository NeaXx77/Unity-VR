using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
public class UIManager : MonoBehaviour
{
    [SerializeField] private InputActionAsset actionAsset;
    [SerializeField] private GameObject canvasUI;
    bool isUIActive = false;

    [SerializeField] public static UIManager instance;
    public bool isGameStarted = false;
    [SerializeField] Transform area;
    [SerializeField] private TeleportationProvider provider;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        var activate = actionAsset.FindActionMap("XRI LeftHand").FindAction("ActivateUI");
        activate.Enable();
        activate.performed += ActivateUI;
    }

    //Press Left primary button to activate UI
    private void ActivateUI(InputAction.CallbackContext callback){
        canvasUI.SetActive(!isUIActive);
        isUIActive = !isUIActive;
    }

    //Use in the start button next to sabers
    public void StartBeatSaber(){
        isGameStarted = true;
        TeleportRequest request = new TeleportRequest(){
            destinationPosition = area.position,
        };
        provider.QueueTeleportRequest(request);
    }
    
}
