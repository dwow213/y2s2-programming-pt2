using UnityEngine;

public class Deceleration : MonoBehaviour
{
    Rigidbody rb;
    Vector3 directionVector;
    float strength;
    public float decelerationSpeed;

    float collidingTimer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (strength > 0)
        {
            Move();
        }

    }

    public void AddKinematicForce(Vector3 tempDirectionVector, float tempStrength)
    {
        directionVector = tempDirectionVector;
        strength = tempStrength;
    }

    void Move()
    {
        transform.position += directionVector * strength * Time.deltaTime;
        Decelerate();
    }

    void Decelerate()
    {
        print("decelerating");
        strength -= decelerationSpeed * Time.deltaTime;

        if (strength <= 0)
        {
            strength = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (strength > 0)
        {
            strength /= 2;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        collidingTimer += Time.deltaTime;
        if (strength > 0 && collidingTimer == 0.5f)
        {
            strength /= 2;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        collidingTimer = 0;
    }

    void DecelerateRigidbody()
    {
        print("decelerating");
        rb.linearVelocity -= decelerationSpeed * Time.deltaTime * rb.linearVelocity.normalized;

        if (rb.linearVelocity.magnitude <= 0)
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
}
