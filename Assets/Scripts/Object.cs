using UnityEngine;

public abstract class Object : MonoBehaviour
{
    public float spawnForce = 12f;
    public Rigidbody2D rb;

    public GameManager gameManager;

    protected void Start()
    {
        gameManager = GameObject.Find("Game").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * spawnForce, ForceMode2D.Impulse);
    }
    protected void Update()
    {
        if (gameObject.isOffScreen()) //transform.position.y < -10f
        {
            if(gameObject.tag == "Fruit")
            {
                gameManager.LoseLife();
            }
            Destroy(gameObject);
        }
    }
}