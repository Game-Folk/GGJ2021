using UnityEngine;
using UnityEngine.Networking;
using TMPro;

#pragma warning disable 0618
public class NetworkManagerSlugs : NetworkManager
#pragma warning restore 0618
{
    // [SerializeField] private GameObject leaderboardPrefab;
    // private LeaderboardManager leaderboardManager;

#pragma warning disable 0618
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
#pragma warning restore 0618
    {
        GameObject player = (GameObject)Instantiate(playerPrefab, GetStartPosition().position, Quaternion.identity);

        // attach score to player
        // TMP_Text scoreText = leaderboardManager.AddScoreToLeaderboard().GetComponent<TMP_Text>();
        // player.GetComponent<FoodConsumption>().SetScoreText(scoreText);

#pragma warning disable 0618
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
#pragma warning restore 0618
    }

//     public override void OnServerSceneChanged(string sceneName)
//     {
//         base.OnServerSceneChanged(sceneName); 

//         if(sceneName != "Menu")
//         {
//             leaderboardManager = GameObject.Find("Leaderboard").GetComponent<LeaderboardManager>();
//             // On server startup, instantiate leaderboard
//             GameObject UICanvas = GameObject.Find("UICanvas");
//             GameObject leaderboard = Instantiate(leaderboardPrefab, UICanvas.transform);
//             leaderboardManager = leaderboard.GetComponent<LeaderboardManager>();
// #pragma warning disable 0618
//             NetworkServer.Spawn(leaderboard);
// #pragma warning restore 0618
//         }
//     }
}
