using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public CarController carController;


    [SerializeField]
    private Image fuelGauge;

    [SerializeField]
    private Text distanceText;

    [SerializeField]
    private Text coinText;

    private int moneyEarned = 0;

    void Start()
    {
        Debug.Log("start");
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceText.text = (int)(carController.transform.position.x - carController.StartPos.x) + "m / <color=yellow>1427m</color>";
        
    }

    public void FuelCharge() {
        Debug.Log(carController.Fuel);
        fuelGauge.fillAmount = 1;
        carController.Fuel = 1;
    }

    public void FuelConsume() {
        fuelGauge.fillAmount = carController.Fuel; 
        if(fuelGauge.fillAmount <= 0.6f) {
            fuelGauge.color = new Color(1, fuelGauge.fillAmount * 0.8f * 2f, 0, 1);
        }
        else {
            fuelGauge.color = new Color((1f - fuelGauge.fillAmount) * 2f, 1, 0, 1);  
        }
    }

    public void EarnCoin(int coin) {
        moneyEarned += coin;
        coinText.text = moneyEarned.ToString();
    }
}
