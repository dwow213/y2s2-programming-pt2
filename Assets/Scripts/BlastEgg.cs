using UnityEngine;

public class BlastEgg : MonoBehaviour
{
    public GameObject currentEgg;
    public float blastPower = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && currentEgg != null)
        {
            BlastAwayEgg();
        }
    }

    void BlastAwayEgg()
    {
        print("blast away egg");
        Rigidbody eggRb = currentEgg.GetComponent<Rigidbody>();
        Vector3 directionVector = currentEgg.transform.position - transform.position;
        eggRb.AddForce(directionVector.normalized * Mathf.Pow(blastPower, 2));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Egg"))
        {
            currentEgg = collision.gameObject;
            currentEgg.GetComponent<Egg>().playerEgg = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject == currentEgg)
        {
            currentEgg.GetComponent<Egg>().playerEgg = false;
            currentEgg = null;
            
        }
    }
}
