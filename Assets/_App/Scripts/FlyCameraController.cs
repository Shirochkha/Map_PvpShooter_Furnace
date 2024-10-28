using UnityEngine;

public class FlyCameraController : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float lookSpeed = 2f;
    public float verticalLookLimit = 80f; 

    private float rotationX = 0f; 

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float moveY = 0f;

        if (Input.GetKey(KeyCode.Space)) 
            moveY += moveSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift)) 
            moveY -= moveSpeed * Time.deltaTime;

        transform.Translate(moveX, moveY, moveZ);

        if (Input.GetMouseButton(1)) 
        {
            float rotX = Input.GetAxis("Mouse X") * lookSpeed;
            rotationX -= Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -verticalLookLimit, verticalLookLimit);

            transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y + rotX, 0);
        }
    }
}
