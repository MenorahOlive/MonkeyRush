using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollisons : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private PowerUpManager powerUpManager;

    static PowerUpManager.PowerUpType bananaType = PowerUpManager.PowerUpType.Banana;
    static PowerUpManager.PowerUpType melonType = PowerUpManager.PowerUpType.Melon;
    static PowerUpManager.PowerUpType grapeType = PowerUpManager.PowerUpType.Grape;


    static PowerUpManager.PowerUp banana = new PowerUpManager.PowerUp(bananaType);
    static PowerUpManager.PowerUp melon = new PowerUpManager.PowerUp(melonType);
    static PowerUpManager.PowerUp grape = new PowerUpManager.PowerUp(grapeType);

    private void OnTriggerEnter(UnityEngine.Collider collision)
    {
        GameObject gameObject = collision.gameObject;
        if (collision.gameObject.CompareTag("Banana"))
        {
            PowerUpInteraction(banana, gameObject);
           
        }
        else if (collision.gameObject.CompareTag("Watermelon"))
        {
            PowerUpInteraction(melon, gameObject);


        }
        else if (collision.gameObject.CompareTag("Grapes"))
        {
            PowerUpInteraction(grape, gameObject);


        }
    }

    public void PowerUpInteraction(PowerUpManager.PowerUp powerUp, GameObject gameObject)
    {
        var isAdded = powerUpManager.AddPowerUp(powerUp);
        if (isAdded)
        {
            Destroy(gameObject);
        }
    }
    

    

}
