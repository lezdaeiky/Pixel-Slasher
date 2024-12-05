using UnityEngine;

public class Bomb : Object
{
    public ParticleSystem explosion;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Blade")
        {
            ParticleSystem explosionEffect = Instantiate(explosion, transform.position, Quaternion.identity);
            explosionEffect.Play();
            gameManager.LoseLife();
            Destroy(gameObject);
        }
    }
}
