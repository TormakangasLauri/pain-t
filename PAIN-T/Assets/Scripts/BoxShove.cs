using UnityEngine;

public class BoxShove : MonoBehaviour
{
    public float minInterval = 1f;
    public float maxInterval = 3f;
    public float shoveForce = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(ShoveRoutine());
    }

    System.Collections.IEnumerator ShoveRoutine()
    {
        while (true)
        {
            float wait = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(wait);

            Vector3 randomDir = Random.onUnitSphere;
            rb.AddForce(randomDir * shoveForce, ForceMode.Impulse);
        }
    }
}
