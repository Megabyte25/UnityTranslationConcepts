using UnityEngine;
using UnityEngine.Assertions;

public class TranslateWithArrival : MonoBehaviour
{
    public GameObject Target;
    public float Speed;
    public float ArrivalRadius;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(Target, "A target game object must be assigned.");
        Assert.IsTrue(Speed > 0.0f, "Speed must be greater than 0.");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Target.transform.position - transform.position;
        float distance = direction.magnitude;

        // Continue translating only if we are outside the arrival radius
        if (distance > ArrivalRadius)
        {
            transform.Translate(direction.normalized * Speed * Time.deltaTime);
        }
    }
}
