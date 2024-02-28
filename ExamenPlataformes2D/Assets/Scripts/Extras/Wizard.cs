using UnityEngine;

public class Wizard : Character
{
    public float protection = 50f;

    public override void TakeDamage(float amount)
    {
        if (protection > 0)
        {
            float remainingProtection = protection - amount;
            if (remainingProtection >= 0)
            {
                protection = remainingProtection;
                Debug.Log("Wizard's protection absorbed the damage.");
            }
            else
            {
                health -= Mathf.Abs(remainingProtection);
                protection = 0;
                Debug.Log("Wizard's protection absorbed partial damage. Health reduced.");
            }
        }
        else
        {
            health -= amount;
        }

        if (health <= 0)
        {
            Die();
        }
    }
}
