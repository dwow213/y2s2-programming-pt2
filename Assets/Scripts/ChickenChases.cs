using NodeCanvas.Framework;
using UnityEngine;
using UnityEngine.AI;

public class ChickenChases : MonoBehaviour
{
    Blackboard blackboard;
    public float pushPower;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        blackboard = GetComponent<Blackboard>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        print($"collision: {collision.gameObject}, {collision.gameObject.tag}");

        if (!blackboard.GetVariableValue<bool>("currentlyAttacking"))
            return;

        if (!collision.gameObject.CompareTag("Player") && !collision.gameObject.CompareTag("Opponent"))
            return;

        if (collision.gameObject != blackboard.GetVariableValue<GameObject>("pushTarget"))
            return;

        Deceleration hitObject = collision.gameObject.GetComponent<Deceleration>();
        Vector3 directionVector = collision.transform.position - transform.position;
        print($"dir vector: {directionVector}, vel: {directionVector.normalized * Mathf.Pow(pushPower, 2)}");
        hitObject.AddKinematicForce(directionVector, pushPower);
        //collision.rigidbody.AddForce(directionVector.normalized * Mathf.Pow(pushPower, 2));
        //collision.rigidbody.linearVelocity = directionVector.normalized * Mathf.Pow(pushPower, 2);
        print($"vel: {collision.rigidbody.linearVelocity}");
        blackboard.SetVariableValue("currentlyAttacking", false);
        print("PUSHING P");
    }
}
