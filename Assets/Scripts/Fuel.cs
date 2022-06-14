using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Vehicle")){
            GameManager.Instance.FuelCharge();
            gameObject.SetActive(false);
        }
    }
}
