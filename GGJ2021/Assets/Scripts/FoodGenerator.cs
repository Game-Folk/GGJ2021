using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 0618
public class FoodGenerator : NetworkBehaviour
#pragma warning restore 0618
{
    [SerializeField] private float secondsBtwnSpawn = 3.0f;
    [SerializeField] private List<GameObject> spawnPoints;
    [SerializeField] private List<GameObject> spawnables;

    private List<GameObject> spawnPointsOccupied = new List<GameObject>();

    /* UnOccupySpawnPoint() moves spawn points from occupied list to
     * original list.
     * returns false if no spawn point was not removed
     */
    public bool UnOccupySpawnPoint(GameObject spawnPoint)
    {
        if(spawnPoint != null)
        {
            spawnPoints.Add(spawnPoint); // return sp to pool
            spawnPointsOccupied.Remove(spawnPoint); // remove flag as occupied
            return true;
        }

        Debug.Log("UnOccupySpawnPoint(): failed to unoccupy spawn point " + spawnPoint);
        return false;
    }

    // Start is called before the first frame update
    void Start()
    {
        // if this object is not on the server, don't run the following
        if(!isServer) return;

        if(spawnPoints.Count <= 0) Debug.Log("FoodGenerator: no spawn points, did you forget to set them?");

        StartCoroutine("SpawnSpawnable");
    }

    IEnumerator SpawnSpawnable()
    {
        while(true)
        {
            // only if spawn points available
            if(spawnPoints.Count > 0)
            {
                GameObject spawnableChosen = PickSpawnable();
                Transform spawnPointChosen = PickSpawnPoint().transform;
                GameObject spawnedObject = Instantiate(spawnableChosen, spawnPointChosen);

                // set the reference so we can UnOccupySpawnPoint later
                spawnedObject.GetComponent<FoodGeneratorReference>().SetFoodGenerator(this);
#pragma warning disable 0618
                NetworkServer.Spawn(spawnedObject);
#pragma warning restore 0618 
            }

            yield return new WaitForSeconds(secondsBtwnSpawn);
        }
    }

    private GameObject PickSpawnable()
    {
        int randomIndex = Random.Range(0, spawnables.Count-1);

        return spawnables[randomIndex];
    }

    private GameObject PickSpawnPoint(){
        int randomIndex = Random.Range(0, spawnPoints.Count-1);

        GameObject spawnPointPicked = spawnPoints[randomIndex];
        spawnPointsOccupied.Add(spawnPointPicked); // flag as occupied
        spawnPoints.Remove(spawnPointPicked); // remove from pool to choose from

        return spawnPointPicked;
    }
}
