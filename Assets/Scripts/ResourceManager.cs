using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ResourceManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI earthText;
    [SerializeField]
    private TextMeshProUGUI fireText;
    [SerializeField]
    private TextMeshProUGUI waterText;
    [SerializeField]
    private TextMeshProUGUI airText;
    [SerializeField]
    private TextMeshProUGUI goldText;

    private int earthAmount;
    private int fireAmount;
    private int waterAmount;
    private int airAmount;
    private int goldAmount;
    public int getEarthAmount() { return earthAmount; }
    public int getFireAmount() { return fireAmount; }
    public int getWaterAmount() { return waterAmount; }
    public int getAirAmount() { return airAmount; }
    public int getGoldAmount() { return goldAmount; }
    public ResourceManager()
    {
        earthAmount = 0;
        fireAmount = 0;
        waterAmount = 0;
        airAmount = 0;
        goldAmount = 0;
    }

    public void UpdateResource(string type, int amount)
    {
        switch(type)
        {
            case "earth": earthAmount += amount;
                earthText.text = "" + earthAmount;
                break;
            case "fire":
                fireAmount += amount;
                fireText.text = "" + fireAmount;
                break;
            case "water":
                waterAmount += amount;
                waterText.text = "" + waterAmount;
                break;
            case "air":
                airAmount += amount;
                airText.text = "" + airAmount;
                break;
            case "gold":
                goldAmount += amount;
                goldText.text = "" + goldAmount;
                break;
        }
    }
}
