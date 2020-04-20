using UnityEngine;

public enum InteractableType { NPC } // TODO

public interface IInteractable
{
    void OnInteract(GameObject entity);
    void OnRange();
    void OutOfRange();
}