
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float panSpeed = 30f;
    public float panBorderThicness = 10f;
    public float scrollSpeed = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    void Update()
    {

        if(GameManager.gameIsOver)
        {
           this.enabled = false; 
           return;
        }
        
        
        if (Input.GetKey("w") || Input.mousePosition.y >= Screen.height - panBorderThicness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);
        }

         if (Input.GetKey("s") || Input.mousePosition.y <= panBorderThicness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);
        }

         if (Input.GetKey("d") || Input.mousePosition.x >= Screen.width - panBorderThicness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);
        }

         if (Input.GetKey("a") || Input.mousePosition.x <=  panBorderThicness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");

        Vector3 pos = transform.position;

        pos.y -= scroll * 1000 * scrollSpeed * Time.deltaTime;
        pos.y = Mathf.Clamp (pos.y,minY,maxY);

        transform.position = pos;





    }
}
