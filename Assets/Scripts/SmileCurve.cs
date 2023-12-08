using UnityEngine;
using System.Collections;
public class SmileCurve : MonoBehaviour
{
    // Normal Face
    public GameObject smile; // dont change after loss, change after win
    
    // Lost Game Face
    public GameObject frownEyebrowLeft;
    public GameObject frownEyebrowRight;
    public GameObject tear;
    
    // Won Game Face
    public GameObject WinningSmile;
    
    public SimpleTimer gameTimer; // Assign a reference to your SimpleTimer script
    public int pointsCount = 50;
    private float maxSmileWidth = 0.25f; // Adjust this value to match the size of the sphere's mouth area

    private LineRenderer lineRenderer;

    private void Start()
    {
        if (smile != null)
        {
            lineRenderer = smile.GetComponent<LineRenderer>();
            if (lineRenderer == null)
            {
                Debug.LogError("LineRenderer component not found on the smile GameObject!");
                return;
            }
        }
        else
        {
            Debug.LogError("Smile GameObject is not assigned!");
            return;
        }

        if (gameTimer == null)
        {
            Debug.LogError("GameTimer script is not assigned!");
            return;
        }

        lineRenderer.positionCount = pointsCount;
        UpdateLine(0); // Start with a smile
    }

    private void Update()
    {
        if (gameTimer == null) return;

        // Calculate the progress based on the game timer
        float progress = gameTimer.currentTime / gameTimer.timeLimit;

        // Ensure progress does not exceed 1
        progress = Mathf.Clamp01(progress);

        // Update the line based on progress
        UpdateLine(progress);
    }

    public void UpdateLine(float progress)
    {
        Vector3[] points = new Vector3[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            float t = i / (float)(pointsCount - 1);
            float x = (t * 2f - 1f) * maxSmileWidth; // Adjust x range to control the width
            // Reverse the Lerp to start from a smile and end with a frown
            float y = Mathf.Lerp(-Mathf.Sin(t * Mathf.PI) * maxSmileWidth, Mathf.Sin(t * Mathf.PI) * maxSmileWidth, progress);
            points[i] = new Vector3(x, y, 0f);
        }
        lineRenderer.SetPositions(points);
    }
    
    private void ResetToFullSmile()
    {
        Vector3[] points = new Vector3[pointsCount];
        for (int i = 0; i < pointsCount; i++)
        {
            float t = i / (float)(pointsCount - 1);
            float x = (t * 2f - 1f) * maxSmileWidth; // X range from -maxSmileWidth to maxSmileWidth
            float y = Mathf.Sin(t * Mathf.PI) * maxSmileWidth; // Full smile curve
            points[i] = new Vector3(x, y, 0f);
        }
        lineRenderer.SetPositions(points);
    }
    
    public void OnLose()
    {
        Debug.Log("Losing Face should activate.");
        frownEyebrowLeft.SetActive(true);
        frownEyebrowRight.SetActive(true);
        tear.SetActive(true);
    }
    
    public void OnWin()
    {
        Debug.Log("Winning Face should activate.");
        smile.SetActive(false);
        WinningSmile.SetActive(true);
    }
}
    