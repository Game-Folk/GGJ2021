using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 0618
public class FoodGeneratorReference : NetworkBehaviour
#pragma warning restore 0618
{
    private FoodGenerator foodGenerator;

    public void SetFoodGenerator(FoodGenerator foodGen)
    {
        foodGenerator = foodGen;
    }

    public FoodGenerator GetFoodGenerator()
    {
        return foodGenerator;
    }
}
