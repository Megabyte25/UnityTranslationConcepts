using UnityEngine;
using UnityEngine.Assertions;

public class TranslateWithSlowAndArrival : MonoBehaviour
{
    public GameObject Target;
    public float MaxSpeed;
    public float SlowRadius;
    public float ArrivalRadius;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(Target, "A target game object must be assigned.");
        Assert.IsTrue(MaxSpeed > 0.0f, "MaxSpeed must be greater than 0.");
        Assert.IsTrue(SlowRadius > ArrivalRadius, "SlowRadius must be greater than ArrivalRadius.");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Target.transform.position - transform.position;
        float distance = direction.magnitude;
        if (distance > SlowRadius)
        {
            // Move at full speed if we are outside the slow radius
            transform.Translate(direction.normalized * MaxSpeed * Time.deltaTime);
        }
        else if (distance > ArrivalRadius)
        {
            // Move at reduced speed between the slow and arrival radii
            float percent = (distance - ArrivalRadius) / (SlowRadius - ArrivalRadius);
            transform.Translate(direction.normalized * MaxSpeed * percent * Time.deltaTime);
        }
    }
}
