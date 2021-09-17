using UnityEngine;

public class Cube : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot =  Quaternion.Euler(0, 1, 1);
        transform.rotation = this.transform.rotation * rot;
    }
}
