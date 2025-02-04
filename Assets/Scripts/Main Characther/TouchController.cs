using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class TouchController : MonoBehaviour
{
    [Range(0.5f, 2f)][SerializeField] private float sense;
    private Vector2 m_Position;
    [SerializeField]private float fowardSpeed;
    public bool started=false;
    

    // Update is called once per frame
    void Update()
    {
        if (!started) return;
        
        if (Input.GetMouseButton(0))
        {
            Move(Input.mousePosition.x - m_Position.x);
        }
        m_Position = Input.mousePosition;
        this.transform.Translate(Vector3.forward * fowardSpeed * Time.deltaTime);
    }

    void Move(float speed)
    {
        transform.position += Vector3.right * speed * Time.deltaTime * sense;
        
    }

    public void StartGame()
    {
        started = true;
    }
}
