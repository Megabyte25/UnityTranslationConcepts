using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    // Array of game objects whose positions can be reset
    public GameObject[] GameObjectsToReset;
    private Dictionary<GameObject, Vector3> startingPositions;

    // (Taking a shortcut to reset these below)
    public Lerp LerpToReset;
    public LerpWithAnimationCurve LerpAnimCurveToReset;

    void Start()
    {
        startingPositions = new Dictionary<GameObject, Vector3>();
        foreach (GameObject obj in GameObjectsToReset)
        {
            startingPositions.Add(obj, obj.transform.position);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            foreach(GameObject obj in GameObjectsToReset)
            {
                Vector3 value;
                if (startingPositions.TryGetValue(obj, out value))
                {
                    obj.transform.position = value;
                }
            }

            LerpToReset.Reset();
            LerpAnimCurveToReset.Reset();
        }
    }
}
