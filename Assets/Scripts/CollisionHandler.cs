using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Debug.Log("Collision detected with: " + other.gameObject.name);
        Destroy(this.gameObject);
    }
}
