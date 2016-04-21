using UnityEngine;
using System.Collections;

public class Mouse : MonoBehaviour {

    Transform selectedTransform;

    Rigidbody rb;

    float mouseDistance = 1.0f;
    float maxMouseDistance = 2f;
    float minMouseDistance = 0.3f;

    Vector3 startPos;

	// Use this for initialization
	void Start () {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
        //Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown("escape")) {
        //    Cursor.lockState = CursorLockMode.None;
        //}

	    if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f)) {
                selectedTransform = hit.collider.transform;
            }
        }

        float deltaScroll = Input.GetAxis("Mouse ScrollWheel");
        if (deltaScroll != 0) {
            mouseDistance += deltaScroll;
            mouseDistance = Mathf.Clamp(mouseDistance, minMouseDistance, maxMouseDistance);
            
        }

        
	}

    void FixedUpdate() {
        Vector3 mouse = Input.mousePosition;
        Debug.Log("mouse: " + Input.mousePosition);
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, mouse.y, mouseDistance));
        newPosition += startPos;
        rb.MovePosition(newPosition);

        if (selectedTransform != null) {
            
        }
    }
}
