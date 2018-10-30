using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    private CharacterController characterController;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        characterController.height = Input.GetKey(KeyCode.C) ? 0.8f : 1.8f;
    }
}
