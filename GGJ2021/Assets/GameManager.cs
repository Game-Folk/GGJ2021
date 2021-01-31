using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 0618
public class GameManager : NetworkBehaviour
#pragma warning restore 0618
{
    [SerializeField] GameObject slugPrefab;
    [SerializeField] GameObject saltPrefab;

    public void BecomeSlug()
    {
        // dunno how to find specific player
#pragma warning disable 0618
        NetworkIdentity player = GameObject.Find("PlayerSlug").GetComponent<NetworkIdentity>();
#pragma warning restore 0618

        var conn = player.connectionToClient;
        var newPlayer = Instantiate<GameObject>(slugPrefab);
        Destroy(player.gameObject);
#pragma warning disable 0618
        NetworkServer.ReplacePlayerForConnection(conn, newPlayer, 0);
#pragma warning restore 0618
    }
    
}
