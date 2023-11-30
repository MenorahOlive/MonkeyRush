using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpManager : MonoBehaviour
{
    public enum PowerUpType { Banana, Melon, Grape }
    public class PowerUp
    {
        public PowerUpType powerUpType;

        public PowerUp(PowerUpType powerUpType)
        {
            this.powerUpType = powerUpType;
        }


    }


    [SerializeField] private Sprite bananaIcon;
    [SerializeField] private Sprite melonIcon;
    [SerializeField] private Sprite grapeIcon;
    [SerializeField] private GameObject[] uiSlots;

    //Car Powerup Object
    [SerializeField] private CarPowerup carPowerup;

    //Sound Effects
    private AudioSource eatingSoundEffect;
    private AudioSource powerUpSoundEffect;

   
    private List<PowerUp> availablePowerups;
    // Start is called before the first frame update
    void Start()
    {
        availablePowerups = new List<PowerUp>();
        AudioSource[] soundEffects = GetComponents<AudioSource>();
        eatingSoundEffect = soundEffects[0];
        powerUpSoundEffect = soundEffects[1];


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Keypad1))
        {
            if(availablePowerups.Count >0) {
            
            PowerUp powerUp = availablePowerups[0];
            UsePowerUp(powerUp);
            }
        }
        if (Input.GetKey(KeyCode.Keypad2))
        {
            if (availablePowerups.Count > 1)
            {

            PowerUp powerUp = availablePowerups[1];
            UsePowerUp(powerUp);
            }
        }

    }

    public bool AddPowerUp(PowerUp powerUp)
    {

        if (availablePowerups.Count < 2 && !availablePowerups.Contains(powerUp))
        {
            availablePowerups.Add(powerUp);
            eatingSoundEffect.Play();
            UpdatePowerUpUI();
            return true;
        }
        return false;

    }
    public bool RemovePowerUp(PowerUp powerUp)
    {
        if (availablePowerups.Contains(powerUp))
        {
            RemovePowerUpUi(powerUp);
            availablePowerups.Remove(powerUp);

            return true;
        }
        return false;
    }

    public void UsePowerUp(PowerUp powerUp)
    {
        powerUpSoundEffect.Play();
       if(powerUp.powerUpType == PowerUpType.Banana)
        {
            carPowerup.SpeedBoost();
        }
       else if(powerUp.powerUpType == PowerUpType.Melon)
        {
            carPowerup.ForceField();
        }
       else if(powerUp.powerUpType == PowerUpType.Grape)
        {
            carPowerup.Invisisbity();
        }
        RemovePowerUp(powerUp);
    }

    void UpdatePowerUpUI()
    {
        for (int i = 0; i < availablePowerups.Count; i++)
        {
            PowerUp powerUp = availablePowerups[i];
            GameObject uiSlot = uiSlots[i];
            Image[] imageComponents = uiSlot.GetComponentsInChildren<Image>();
            Image backgroundColor = imageComponents[1];
            Image uiImage = imageComponents[2];
            if (powerUp.powerUpType == PowerUpType.Banana)
            {
                backgroundColor.color = new Color32(255, 234, 56, 255);
                uiImage.sprite = bananaIcon;
                uiImage.color = new Color32(255, 255, 255, 255);
            }
            else if (powerUp.powerUpType == PowerUpType.Melon)
            {
                backgroundColor.color = new Color32(255, 57, 146, 255);

                uiImage.sprite = melonIcon;
                uiImage.color = new Color32(255, 255, 255, 255);

            }
            else if (powerUp.powerUpType == PowerUpType.Grape)
            {
                backgroundColor.color = new Color32(157, 56, 255, 255);

                uiImage.sprite = grapeIcon;
                uiImage.color = new Color32(255, 255, 255, 255);

            }

        }


    }
    void RemovePowerUpUi(PowerUp powerUp)
    {
        var index = availablePowerups.IndexOf(powerUp);

        if (index >= 0)
        {
            GameObject uiSlot = uiSlots[index];
            if (uiSlot != null)
            {
                Image[] imageComponents = uiSlot.GetComponentsInChildren<Image>();
                Image backgroundColor = imageComponents[1];
                Image uiImage = imageComponents[2];

                backgroundColor.color = new Color32(40, 40, 40, 255);
                uiImage.sprite = null;
                uiImage.color = new Color32(40, 40, 40, 40);

            }
        }

    }


}
