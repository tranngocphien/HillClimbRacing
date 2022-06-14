using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField]
    private WheelJoint2D frontTire, backTire;
    [SerializeField]
    private float speed;

    private float movement = 0f;
    private float moveSpeed = 0f;
    private float fuel = 1, fuelConsumption = 0.05f;

    public float Fuel {
        get => fuel; set { fuel = value; }
    }

    public Vector3 StartPos { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)){
            movement += 0.009f;
            if(movement > 1f)
                movement = 1f;
        }
        else if(Input.GetKey(KeyCode.LeftArrow)){
            movement -= 0.009f;
            if(movement < -1f)
                movement = -1f;
        }
        else if(!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) {
            movement = 0;
        }

        moveSpeed = movement * speed;
        GameManager.Instance.FuelConsume();

        
    }


    void FixedUpdate() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, StartPos.x, transform.position.x), transform.position.y);

        if(moveSpeed.Equals(0) || fuel < 0 ){
            frontTire.useMotor = false;
            backTire.useMotor = false;
        }
        else {
            frontTire.useMotor = true;
            backTire.useMotor = true;
            JointMotor2D motor = new JointMotor2D();
            motor.motorSpeed = moveSpeed;
            motor.maxMotorTorque = 10000;
            frontTire.motor = motor;
            backTire.motor = motor;
        }

        fuel -= fuelConsumption * Mathf.Abs(movement) * Time.fixedDeltaTime;


    }
}
