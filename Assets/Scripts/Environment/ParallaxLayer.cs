using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
    public Transform target;
    public float parallaxMultiplier = 0.5f;
    public bool followY = false;

    private Vector3 startPosition;
    private Vector3 targetStartPosition;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        targetStartPosition = target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetMove = target.position - targetStartPosition;

        Vector3 newPosition = startPosition + targetMove * (1.0f - parallaxMultiplier);

        if(followY == false)
        {
            newPosition.y = startPosition.y;
        }

        newPosition.z = startPosition.z;
        transform.position = newPosition;
    }
}
