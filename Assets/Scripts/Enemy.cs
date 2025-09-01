using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] GameObject deathVFX;
    [SerializeField] int hitPoints = 10;
    private void OnParticleCollision(GameObject other)
    {
        hitPoints--;
        if (hitPoints <= 0)
        {
            Instantiate(deathVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
