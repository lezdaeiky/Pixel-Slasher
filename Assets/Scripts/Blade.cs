using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting = false;

    public GameObject bladeTrailPrefab;
    public int minVelocity = 10;

    GameObject currentBladeTrail;

    Rigidbody2D rb;
    Collider2D col;

    Vector2 previousPosition;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
        col.enabled = false;
    }

    void Update()
    {
        Vector2 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.position = currentMousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut(currentMousePosition);
        }

        previousPosition = currentMousePosition;
    }

    void UpdateCut(Vector2 currentMousePosition)
    {
        float velocity = (currentMousePosition - previousPosition).magnitude / Time.deltaTime;

        col.enabled = velocity > minVelocity;
    }

    void StartCutting()
    {
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
        col.enabled = false;
        previousPosition = rb.position;
    }

    void StopCutting()
    {
        isCutting = false;
        col.enabled = false;

        if (currentBladeTrail != null)
        {
            currentBladeTrail.transform.SetParent(null);
            Destroy(currentBladeTrail, 2f);
        }
    }
}
