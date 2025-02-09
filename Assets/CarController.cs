using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveAmount = 1f; // Amount to increase the X position by when "move" is called
    private bool isMoving = false;
    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    // Method to move the car along the X-axis
    private void Update()
    {
        if (isMoving)
        {
            MoveCarForward();
        }
        else if (isMovingLeft)
        {
            MoveLeft();
        }
        else if (isMovingRight)
        {
            MoveRight();
        }
    }

    public void MoveForward()
    {
        // Increase the Y position directly to create the feeling of movement
        isMoving = true;
        // Optional: Log the position for debugging
        Debug.Log($"Car moved to Y: {transform.position.y}");
    }

    public void MoveCarForward()
    {
        // Increase the Y position directly to create the feeling of movement
        transform.position = new Vector3(transform.position.x, transform.position.y + moveAmount, transform.position.z);
        isMoving = true;
        // Optional: Log the position for debugging
        Debug.Log($"Car moved to Y: {transform.position.y}");
    }

    // Method to move the car to the left along the X-axis
    public void MoveLeft()
    {
        transform.Rotate(0, 0, 90);
        transform.position = new Vector3(transform.position.x - moveAmount, transform.position.y, transform.position.z);
        isMovingLeft = true; // Stop the left movement after one move
        // Optional: Log the position for debugging
        Debug.Log($"Car moved to X: {transform.position.x}");
    }

    // Method to move the car to the right along the X-axis
    public void MoveRight()
    {
        transform.Rotate(0, 0, -90);
        transform.position = new Vector3(transform.position.x + moveAmount, transform.position.y, transform.position.z);
        isMovingRight = true; // Stop the right movement after one move
        // Optional: Log the position for debugging
        Debug.Log($"Car moved to X: {transform.position.x}");
    }

    // Method to stop the car (optional for now)
    public void StopCar()
    {
        moveAmount = 0;
        isMoving = false;
    }

    // Method to start moving left (increment the position on X axis)
    public void StartMoveLeft()
    {
        isMovingLeft = true;
    }

    // Method to start moving right (increment the position on X axis)
    public void StartMoveRight()
    {
        isMovingRight = true;
    }
}
