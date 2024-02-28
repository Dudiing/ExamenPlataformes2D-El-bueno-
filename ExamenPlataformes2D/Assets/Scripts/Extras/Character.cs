using UnityEngine;

public class Character : MonoBehaviour
{
    public float health = 100f;
    public float speed = 5f;

    public virtual void Move(Vector2 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Debug.Log("Character has died.");
        Destroy(gameObject);
    }
}
