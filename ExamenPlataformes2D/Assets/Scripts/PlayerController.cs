using UnityEngine;

[System.Serializable]
public class InputKeys
{
    public KeyCode attackKey = KeyCode.Alpha1;
    public KeyCode hurtKey = KeyCode.Alpha2;
    public KeyCode dieKey = KeyCode.Alpha3;
}

public class PlayerController : MonoBehaviour
{
    [Header("Animaciones")]
    public Animator animator;
    [SerializeField] public InputKeys inputKeys;

    [Header("Teleportación")]
    [SerializeField] private float teleportDistanceX = 5f;
    [SerializeField] private float teleportDistanceY = 5f;

    private void Update()
    {
        if (Input.GetKeyDown(inputKeys.attackKey))
            Attack();
        else if (Input.GetKeyDown(inputKeys.hurtKey))
            Hurt();
        else if (Input.GetKeyDown(inputKeys.dieKey))
            Die();

        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput != 0)
            FlipCharacter(horizontalInput);
    }

    private void Attack()
    {
        animator.SetTrigger("Attack");
    }

    private void Hurt()
    {
        animator.SetTrigger("Hurt");
    }

    private void Die()
    {
        animator.SetTrigger("Die");
    }

    private void FlipCharacter(float horizontalInput)
    {
        Vector3 newScale = transform.localScale;
        newScale.x = Mathf.Sign(horizontalInput);
        transform.localScale = newScale;
    }

    public void Teleport()
    {
        float directionX = Mathf.Sign(transform.localScale.x);
        Vector2 teleportDirection = new Vector2(directionX * teleportDistanceX, teleportDistanceY);

        transform.Translate(teleportDirection);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(teleportDistanceX * Mathf.Sign(transform.localScale.x), teleportDistanceY, 0));
    }
}
