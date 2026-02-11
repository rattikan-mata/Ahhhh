using UnityEngine;

public class Obstacle : MonoBehaviour
{
    Rigidbody rb;

    public void DamageTorque() 
    {
        rb.AddTorque(Vector3.up * 50f);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
