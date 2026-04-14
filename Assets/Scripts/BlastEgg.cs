using UnityEngine;
using UnityEngine.AI;

public class BlastEgg : MonoBehaviour
{
    public GameObject currentEgg;
    public float blastPower = 5;

    // Update is called once per frame
    void Update()
    {
        //blast an egg if they right-click and has a currentEgg registered (touching an egg)
        if (Input.GetMouseButtonDown(1) && currentEgg != null)
        {
            BlastAwayEgg();
        }
    }

    //blast the egg in the direction player is facing
    void BlastAwayEgg()
    {
        Rigidbody eggRb = currentEgg.GetComponent<Rigidbody>();
        Vector3 directionVector = currentEgg.transform.position - transform.position;
        eggRb.AddForce(directionVector.normalized * Mathf.Pow(blastPower, 2));
    }

    private void OnCollisionEnter(Collision collision)
    {
        //if player is touching an egg, register them as the currentEgg
        if (collision.gameObject.CompareTag("Egg"))
        {
            currentEgg = collision.gameObject;
            currentEgg.GetComponent<Egg>().playerEgg = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //if the currentEgg leaves the player (stops touching), unregister them
        if (collision.gameObject == currentEgg)
        {
            currentEgg.GetComponent<Egg>().playerEgg = false;
            currentEgg = null;
        }
    }
}
