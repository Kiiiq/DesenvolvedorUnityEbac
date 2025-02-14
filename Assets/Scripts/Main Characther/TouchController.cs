using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.UIElements;

public class TouchController : MonoBehaviour
{
    [Range(0.5f, 2f)][SerializeField] private float sense;
    private Vector2 m_Position;

    

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - m_Position.x);
        }

        if (Input.GetMouseButtonUp(0)) {
            ResetPosition();
        }
        m_Position = Input.mousePosition;
    }

    private void ResetPosition()
    {
        transform.position = Vector3.zero;
    }

    void Move(float speed)
    {
        transform.position += Vector3.right * speed * Time.deltaTime * sense;
    }


}
