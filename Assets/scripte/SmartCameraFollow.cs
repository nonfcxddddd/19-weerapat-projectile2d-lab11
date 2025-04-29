using UnityEngine;

public class SmartCameraFollow : MonoBehaviour
{
    public Transform target;        
    public float followSpeed = 5f;
    public Vector2 offset = new Vector2(2f, 1f); 

    void Update()
    {
        if (target == null) return;

        Vector3 cameraPos = transform.position;
        Vector3 targetPos = target.position;

        float diffX = targetPos.x - cameraPos.x;

        if (Mathf.Abs(diffX) > offset.x)
        {
            float newX = Mathf.Lerp(cameraPos.x, targetPos.x - Mathf.Sign(diffX) * offset.x, Time.deltaTime * followSpeed);
            cameraPos.x = newX;
        }

        float diffY = targetPos.y - cameraPos.y;
        if (Mathf.Abs(diffY) > offset.y)
        {
            float newY = Mathf.Lerp(cameraPos.y, targetPos.y - Mathf.Sign(diffY) * offset.y, Time.deltaTime * followSpeed);
            cameraPos.y = newY;
        }

        transform.position = new Vector3(cameraPos.x, cameraPos.y, transform.position.z);
    }
}
