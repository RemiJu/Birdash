using UnityEngine;
using UnityEngine.SceneManagement;


public class FallOver : MonoBehaviour
{
    private BoxCollider boxCollider;
    private GameObject unicycle;
    private Transform unicycleTransform;

    private void Start()
    {
        // Get the BoxCollider component attached to the GameObject
        boxCollider = GetComponent<BoxCollider>();
        unicycle = transform.parent.gameObject;
    }

    private void Update()
    {
        // Calculate a ray originating from the center of the box and directed downward
        Ray ray = new Ray(transform.position + boxCollider.center, Vector3.down);

        // Adjust the ray length based on half of the box's height
        float rayLength = boxCollider.size.y / 2.0f;

        // Perform a raycast
        if (Physics.Raycast(ray, rayLength))
        {
            // The box is on the ground
            Debug.Log("You've fallen over!");
            SceneManager.LoadScene(0);
        }
    }
}
