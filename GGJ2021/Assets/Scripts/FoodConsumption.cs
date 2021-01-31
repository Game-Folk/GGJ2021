using UnityEngine;
using UnityEngine.Networking;
using TMPro;

#pragma warning disable 0618
public class FoodConsumption : NetworkBehaviour
#pragma warning restore 0618
{
    [SerializeField] private string defaultScoreText = "";
    [SerializeField] private TMP_Text scoreText;


#pragma warning disable 0618
    [SyncVar]
#pragma warning restore 0618
    private int currentScore = 0;

    // called by NetworkManagerSlugs
    // public void SetScoreText(TMP_Text t)
    // {
    //     scoreText = t;
    // }

    // When the slug player comes into collect with food, destroy food
    private void OnTriggerEnter2D(Collider2D col)
    {
        // check for salt tag
        if(col.gameObject.tag == "Food")
        {
            // unoccupy spawn point of this food you ate
            // obtain ref to the generator (which is on the food)
            FoodGeneratorReference foodGenRef = col.GetComponent<FoodGeneratorReference>();
            FoodGenerator foodGen = foodGenRef.GetFoodGenerator();
            // access food's transform, to access parent, to get its GO
            foodGen.UnOccupySpawnPoint(col.transform.parent.gameObject);

            RpcEat(col.gameObject);
        }
    }

#pragma warning disable 0618
    [ClientRpc]
#pragma warning restore 0618
    private void RpcEat(GameObject food)
    {
        // Increment score
        currentScore++;
        scoreText.text = defaultScoreText + currentScore;

        // TODO: death animation
        Destroy(food, 0);
    }
}
