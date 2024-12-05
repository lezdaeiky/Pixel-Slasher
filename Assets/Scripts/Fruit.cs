using UnityEngine;
using UnityEngine.UIElements;

public class Fuit : Object
{
    public ParticleSystem sliceEffect;
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.tag == "Blade")
        {
            ParticleSystem slice = Instantiate(sliceEffect, transform.position, Quaternion.identity);
            slice.Play();
            gameManager.IcreaseScore();
            Destroy(gameObject);
            Destroy(slice.gameObject, 1f);
        }
    }
}
