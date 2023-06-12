using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShipControl : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float maxSpeed = 100f;
    public float buffDuration = 5f;

    private Camera cam;
    Vector3 direction;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveIt();
        StayInScreen();
    }

    void FixedUpdate()
    {
        if(direction == Vector3.zero)
        {
            return;
        }

        rb.AddForce(direction * moveSpeed, ForceMode.Force);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }
    public void MoveIt()
    {
        if(Touchscreen.current.primaryTouch.press.isPressed)
            {
                Vector2 touchPos = Touchscreen.current.primaryTouch.position.ReadValue();
                Vector3 worldPos = cam.ScreenToWorldPoint(touchPos);

                direction = worldPos - transform.position;
       
                direction.z = 0;

                direction.Normalize();
            }
            else
            {
                direction = Vector3.zero;
            }
    }

    public void StayInScreen(){
        Vector3 newPos = transform.position;
        Vector3 viewPos = cam.WorldToViewportPoint(transform.position);

        if(viewPos.x > 1)
        {
            newPos.x = -newPos.x + 0.2f;
        }
        else if(viewPos.x < 0)
        {
            newPos.x = -newPos.x - 0.2f;
        }

        if(viewPos.y > 1)
        {
            newPos.y = -newPos.y + 0.2f;
        }
        else if(viewPos.y < 0)
        {
            newPos.y = -newPos.y - 0.2f;
        }

        transform.position = newPos;
    }

public void InvinciblityBuffCollected()
{
    Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
    foreach(Renderer renderer in childRenderers)
    {
        Material material = renderer.material;

        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.EnableKeyword("_ALPHABLEND_ON");
        material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;


        Color color = material.color;
        color.a = 0.4f;
        material.color = color;
    }

    GetComponent<Collider>().enabled = false;
    StartCoroutine(DeactivateInvincibility());
}

private IEnumerator DeactivateInvincibility()
{
    yield return new WaitForSeconds(buffDuration);

    Renderer[] childRenderers = GetComponentsInChildren<Renderer>();
    foreach(Renderer renderer in childRenderers)
    {
        Material material = renderer.material;

        // material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        // material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
        // material.SetInt("_ZWrite", 1);
        // material.DisableKeyword("_ALPHATEST_ON");
        // material.DisableKeyword("_ALPHABLEND_ON");
        // material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        // material.renderQueue = -1;

        Color color = material.color;
        color.a = 1f;
        material.color = color;
    }

    GetComponent<Collider>().enabled = true;
}
}
