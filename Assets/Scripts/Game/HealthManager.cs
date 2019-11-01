/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private FloatValue maxHealthValue;
    [SerializeField] private FloatValue currentHealthValue;
    [SerializeField] private Image[] hourglassImages;
    [SerializeField] private Sprite fullSprite;
    [SerializeField] private Sprite halfFullSprite;
    [SerializeField] private Sprite emptySprite;

    public void SetupHealth()
    {
        float temp = maxHealthValue.value / 2;
        for (int i = 0; i < hourglassImages.Length; i++)
        {
            if (i < temp)
            {
                hourglassImages[i].enabled = true;
            }
            else
            {
                hourglassImages[i].enabled = false;
            }
        }
        float halves = currentHealthValue.value;
        for (int i = 0; i < temp; i++)
        {
            if (halves >= 2)
            {
                halves -= 2;
                hourglassImages[i].sprite = fullSprite;
            }
            else if (halves == 1)
            {
                halves -= 1;
                hourglassImages[i].sprite = halfFullSprite;
            }
            else
            {
                hourglassImages[i].sprite = emptySprite;
            }

        }
    }
}*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image[] hourglass;
    public Sprite fullHourglass;
    public Sprite halfHourglass;
    public Sprite emptyHourglass;
    public FloatValue healthContainers;
    public FloatValue playerCurrentHealth;


    // Start is called before the first frame update
    void Start()
    {
        InitHealth();
    }
    public void InitHealth()
    {
        for (int i = 0; i < healthContainers.value; i++)
        {
            if (i < hourglass.Length)
            {
                hourglass[i].gameObject.SetActive(true);
                hourglass[i].sprite = fullHourglass;
            }
        }
    }
    public void UpdateHealth()
    {
        InitHealth();
        float maxhealth = healthContainers.value;
        float tempHealth = playerCurrentHealth.value / 2;
        for (int i = 0; i < healthContainers.value; i++)
        {
            if (i <= tempHealth - 1)
            {
                //Full Heart
                hourglass[i].sprite = fullHourglass;
            }
            else if (i >= tempHealth)
            {
                //empty heart
                hourglass[i].sprite = emptyHourglass;
            }
            else
            {
                //half full heart
                hourglass[i].sprite = halfHourglass;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

    }
}

