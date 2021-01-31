using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// couldnt get to work

#pragma warning disable 0618
public class LeaderboardManager : NetworkBehaviour
#pragma warning restore 0618
{
    [SerializeField] private GameObject scoreTextPrefab;
    [SerializeField] private Transform parentToPutScoresOn;

    private List<GameObject> scoresList;

    public GameObject AddScoreToLeaderboard()
    {
        GameObject spawnedObject = Instantiate(scoreTextPrefab, parentToPutScoresOn);
#pragma warning disable 0618
        NetworkServer.Spawn(spawnedObject);
#pragma warning restore 0618 
        return spawnedObject;
    }
}
