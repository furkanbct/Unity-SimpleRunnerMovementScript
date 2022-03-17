using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float minX;
    [SerializeField] float maxX;

    float lastFingerPosX;
    float moveFactorX;
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                lastFingerPosX = touch.position.x;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                moveFactorX = touch.position.x - lastFingerPosX;
                lastFingerPosX = touch.position.x;
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Stationary)
            {
                moveFactorX = 0;
            }
        }
        float moveAmount = Time.deltaTime * speed * moveFactorX;
        transform.Translate(moveAmount, 0, 0);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), transform.position.y, transform.position.z);
    }
}
