using UnityEngine;
using UnityEngine.Assertions;

public class SimpleTranslate : MonoBehaviour
{
    public GameObject Target;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(Target, "A target game object must be assigned.");
        Assert.IsTrue(Speed > 0.0f, "Speed must be greater than 0.");
    }

    // Update is called once per frame
    void Update()
    {
        // Simply translate towards the target directly
        Vector3 direction = Target.transform.position - transform.position;
        transform.Translate(direction.normalized * Speed * Time.deltaTime);
    }
}
