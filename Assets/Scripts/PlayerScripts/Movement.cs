using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //TowerRotatiingComponents
    [SerializeField] private Transform towerRotator;
    [SerializeField] private Transform towerRotatorStartPos;
    [SerializeField] private Transform leftSideCheck;
    [SerializeField] private Transform rightSideCheck;
    [SerializeField] private LayerMask playerCollisionMask;
    
    //TowerRotatingVariables
    private float rotationSpeed = 25f;
    private float direction;
    private float sideDistance = 0.18f;
    private bool isCollidingFromLeftSide;
    private bool isCollidingFromRightSide;

    //NullVariable
    private float movementSciptNullVariable;

   
    void Start()
    {
        RotatorStartFunction();
    }

    void Update()
    {
        ApplyMovement();
    }

    private void RotatorStartFunction()
    {
        towerRotator.transform.position = towerRotatorStartPos.transform.position;
        towerRotator.transform.rotation = towerRotatorStartPos.transform.rotation;
    }

    private void ApplyMovement()
    {
        MoveLeft();
        MoveRight();
    }

    private void MoveLeft()
    {
        isCollidingFromRightSide = Physics.CheckSphere(rightSideCheck.position, sideDistance, playerCollisionMask);

        if (Input.GetKey(KeyCode.A) && !isCollidingFromRightSide)
        {
            direction = -1f;
            RotateFunction();
        }
        else
        {
            direction = 0f;
        }
    }

    private void MoveRight()
    {
        isCollidingFromLeftSide = Physics.CheckSphere(leftSideCheck.position, sideDistance, playerCollisionMask);

        if (Input.GetKey(KeyCode.D) && !isCollidingFromLeftSide)
        {
            direction = 1f;
            RotateFunction();
        }
        else
        {
            direction = 0f;
        }
    }

    private void RotateFunction()
    {
        transform.Rotate(new Vector3(movementSciptNullVariable, direction * rotationSpeed * Time.deltaTime, movementSciptNullVariable));
    }

}
