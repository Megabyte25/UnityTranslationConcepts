using UnityEngine;
using UnityEngine.Assertions;

public class LerpWithAnimationCurve : MonoBehaviour
{
    public Transform StartMarker;
    public Transform EndMarker;
    public AnimationCurve MoveCurve;

    private float progress;

    // Start is called before the first frame update
    void Start()
    {
        Assert.IsNotNull(StartMarker, "A starting point must be assigned.");
        Assert.IsNotNull(EndMarker, "An ending point must be assigned.");
        Assert.IsNotNull(MoveCurve, "An animation curve must be assigned.");
    }

    // Update is called once per frame
    void Update()
    {
        // Approximately equal: https://docs.unity3d.com/ScriptReference/Vector3-operator_eq.html
        if (transform.position != EndMarker.position)
        {
            // Progress over time using the animation curve
            progress += Time.deltaTime;
            transform.position = Vector3.Lerp(StartMarker.position, EndMarker.position, MoveCurve.Evaluate(progress));
        }
        else
        {
            progress = 0.0f;
        }
    }

    public void Reset()
    {
        transform.position = StartMarker.position;
        progress = 0.0f;
    }
}
