using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField]
    private int value;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Vehicle")){
            GameManager.Instance.EarnCoin(value);
            gameObject.SetActive(false);
        }
    }
}
