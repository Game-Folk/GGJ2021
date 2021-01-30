using UnityEngine;
using TMPro;

public class FoodConsumption : MonoBehaviour
{
    [SerializeField] private string defaultScoreText = "Score: ";

    private TMP_Text scoreText;
    private int currentScore = 0;

    void Awake()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        print(scoreText.text);
    }

    // When the slug player comes into collect with food, destroy food
    private void OnTriggerEnter2D(Collider2D col)
    {
        // check for salt tag
        if(col.gameObject.tag == "Food")
        {
            Eat(col.gameObject);
        }
    }

    private void Eat(GameObject food)
    {
        // Increment score
        currentScore++;
        scoreText.text = defaultScoreText + currentScore;

        // TODO: death animation
        Destroy(food, 0);
    }
}
