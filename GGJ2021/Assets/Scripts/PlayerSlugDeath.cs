using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 0618
public class PlayerSlugDeath : NetworkBehaviour
#pragma warning restore 0618
{
    [SerializeField] GameObject slugPrefab;
    [SerializeField] GameObject saltPrefab;

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

#pragma warning disable 0618
        NetworkIdentity player = GetComponent<NetworkIdentity>();
#pragma warning restore 0618

        var conn = player.connectionToClient;
        var newPlayer = Instantiate<GameObject>(saltPrefab);
        Destroy(player.gameObject);
#pragma warning disable 0618
        NetworkServer.ReplacePlayerForConnection(conn, newPlayer, 0);
#pragma warning restore 0618
        // Destroy(this.gameObject, 0);
    }
}
