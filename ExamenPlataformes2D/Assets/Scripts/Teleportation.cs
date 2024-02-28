using UnityEngine;

public class Teleportation : MonoBehaviour
{
    private PlayerController playerController;

    private void Start()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (playerController == null)
        {
            Debug.LogError("PlayerController no encontrado en el objeto actual.");
            return;
        }

        AnimatorStateInfo stateInfo = playerController.animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("Attack") && stateInfo.normalizedTime >= 0.5f && stateInfo.normalizedTime <= 0.8f)
        {
            playerController.Teleport();
        }
    }
}
