using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting = false;
    GameObject currentBladeTrail;
    CircleCollider2D bladeCollider;

    public GameObject bladeTrail;

    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bladeCollider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        rb.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void StartCutting()
    {
        bladeCollider.enabled = true;
        isCutting = true;
        currentBladeTrail = Instantiate(bladeTrail, transform);
    }

    void StopCutting()
    {
        bladeCollider.enabled = false;
        isCutting = false;
        currentBladeTrail.transform.SetParent(null);
        Destroy(currentBladeTrail, 2f);
    }
}
