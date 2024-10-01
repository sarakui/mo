using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemrotater : MonoBehaviour
{
    //‰ñ“]‚ð‰Á‚¦‚é—Í
    [SerializeField]
    float rotatePower;
    // Start is called before the first frame update
    void Start()
    {
        //‰ñ“]‚³‚¹‚é
        gameObject.GetComponent<Rigidbody>()
            .AddTorque(Vector3.forward * rotatePower, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
