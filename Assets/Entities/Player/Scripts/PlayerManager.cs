using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    private Input controls;

    public PlayerMovement mortdecai;
    public PlayerMovement drull;

    private void Awake() {
        controls = new Input();
        controls.PlayerManager.Switch.performed += _ => SwitchPlayers();
    }

    private void SwitchPlayers() {
        mortdecai.TogglePlaying();
        drull.TogglePlaying();
    }

    void OnEnable() {
        controls.Enable();
    }

    void OnDisable() {
        controls.Disable();
    }
}
