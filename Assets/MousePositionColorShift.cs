using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class MousePositionColorShift : MonoBehaviour
{
    public RectTransform TargetRectTransform;
    private Rect TargetRect;
    public Gradient Gradient;

    private Image Image;


    private float MaxNormalizedDistanceFromEdge;
    void Start()
    {
        TargetRect = TargetRectTransform.rect;

        Image = GetComponent<Image>();

        float DistanceFromHorizontalEdge;

        if(TargetRect.center.x > Screen.width / 2)
        {
            DistanceFromHorizontalEdge = TargetRect.center.x;
        }
        else
        {
            DistanceFromHorizontalEdge = Screen.width -  TargetRect.center.x;
        }

        float DistanceFromVerticalEdge;
        if (TargetRect.center.y > Screen.height / 2)
        {
            DistanceFromVerticalEdge = TargetRect.center.y;
        }
        else
        {
            DistanceFromVerticalEdge = Screen.height - TargetRect.center.y;
        }


        MaxNormalizedDistanceFromEdge = Mathf.Sqrt(Mathf.Pow(DistanceFromHorizontalEdge / Screen.width, 2) + Mathf.Pow(DistanceFromVerticalEdge / Screen.height, 2));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 RelativeMousePosition = new Vector2(Input.mousePosition.x / Screen.width, Input.mousePosition.y / Screen.height);

        float MouseDistanceFromTargetCenter = Mathf.Sqrt(Mathf.Pow((float)(RelativeMousePosition.x - 0.5), 2) + Mathf.Pow((float)(RelativeMousePosition.y - 0.5), 2));

        float GradientAmount = 1 - (MouseDistanceFromTargetCenter * 2) / MaxNormalizedDistanceFromEdge;

        Color c;
        if (GradientAmount < 0f)
        {
            c = Gradient.Evaluate(0);
        }
        else
        {
            c = Gradient.Evaluate(GradientAmount);
        }

        Image.color = c;
    }
}
