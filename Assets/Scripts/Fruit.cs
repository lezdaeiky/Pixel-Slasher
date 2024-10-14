using UnityEngine;

public class Fruit : MonoBehaviour
{
    Rigidbody2D rb;
    public float spawnForce = 160f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * spawnForce, ForceMode2D.Impulse);
    }
}
