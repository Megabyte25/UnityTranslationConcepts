using UnityEngine;
using UnityEngine.Assertions;

public class Lerp : MonoBehaviour
{
    public Transform StartMarker;
    public Transform EndMarker;
    public float TimeToArrival;

    // Variables to keep track of progress internally
    private float timeElapsed = 0.0f;
    private float progress = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(StartMarker, "A starting point must be assigned.");
        Assert.IsNotNull(EndMarker, "An ending point must be assigned.");
        Assert.IsTrue(TimeToArrival > 0.0f, "Arrival time must be a positive number.");
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != EndMarker.position)
        {
            timeElapsed += Time.deltaTime;
            progress = timeElapsed / TimeToArrival;
            transform.position = Vector3.Lerp(StartMarker.position, EndMarker.position, progress);
        }
    }

    public void Reset()
    {
        transform.position = StartMarker.position;
        timeElapsed = 0.0f;
        progress = 0.0f;
    }
}
