using UnityEngine;

public class PlayerSlugDeath : MonoBehaviour
{
    // When the slug player comes into collect with salt, die
    private void OnTriggerEnter2D(Collider2D col)
    {
        // check for salt tag
        if(col.gameObject.tag == "PlayerSalt")
        {
            Die();
        }
    }

    private void Die()
    {
        // TODO: death animation
        Destroy(this.gameObject, 0);
    }
}
