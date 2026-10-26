using UnityEngine;
using UnityEngine.InputSystem;

public class PaintTest : MonoBehaviour
{
Camera m_Camera;
[SerializeField] private RenderTexture paintMask;   // RenderTexture
[SerializeField] private Texture2D brush;           // Brush png
[SerializeField] private float brushSize = 64f;     // Size in pixels


void Start()
    {
        // Clear the mask to black so plane starts unpainted
        Graphics.SetRenderTarget(paintMask);
        GL.Clear(true, true, Color.black);
        Graphics.SetRenderTarget(null);
    }
   void Awake()
   {
       m_Camera = Camera.main;
   }

    void Update()
    {
        // Checks for mouse input
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.isPressed)
       {
        // Get mouse position and cast a ray from the camera to the mouse position
           Vector3 mousePosition = mouse.position.ReadValue();
           Ray ray = m_Camera.ScreenPointToRay(mousePosition);
           if (Physics.Raycast(ray, out RaycastHit hit))
           {
                Debug.Log($"Hit {hit.collider.name} | point: {hit.point} | UV: {hit.textureCoord}");
                //Debug.Log DrawBrush when the raycast hits a collider
                if (hit.collider is MeshCollider)
                {
                    DrawBrush(hit.textureCoord);
                }
           }

       }
    }

    void DrawBrush(Vector2 uv)
    {
        Graphics.SetRenderTarget(paintMask);   // draw onto the mask, not the screen

        GL.PushMatrix();
        GL.LoadPixelMatrix(0, paintMask.width, paintMask.height, 0); // numbers now mean pixels

        // uv goes 0-1, so multiply by the texture size to get pixels.
        // subtracting half the brush size puts the brush's CENTER on the hit (trust me bro)
        // (1 - uv.y) flips Y, because UVs start at the bottom but this setup starts at the top
        float x = uv.x * paintMask.width - brushSize / 2f;
        float y = (1f - uv.y) * paintMask.height - brushSize / 2f;

        Graphics.DrawTexture(new Rect(x, y, brushSize, brushSize), brush);

        GL.PopMatrix();                        // "put back" the drawing setup
        Graphics.SetRenderTarget(null);        // go back to drawing on the screen
    }
}