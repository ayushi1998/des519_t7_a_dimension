using System.Collections;
using UnityEngine;

/// <summary>
/// A helper component that scale the UI rect to the same size as the safe area.
/// </summary>
public class SafeArea : MonoBehaviour
{
    private Rect _screenSafeArea = new Rect(0, 0, 0, 0);

    /// <summary>
    /// Unity's Awake() method.
    /// </summary>
    public void Update()
    {
        Rect safeArea;
#if UNITY_2017_2_OR_NEWER
            safeArea = Screen.safeArea;
#else
        safeArea = new Rect(0, 0, Screen.width, Screen.height);
#endif

        if (_screenSafeArea != safeArea)
        {
            _screenSafeArea = safeArea;
            MatchRectTransformToSafeArea();
        }
    }

    private void MatchRectTransformToSafeArea()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();

        // lower left corner offset
        Vector2 offsetMin = new Vector2(_screenSafeArea.xMin,
            Screen.height - _screenSafeArea.yMax);

        // upper right corner offset
        Vector2 offsetMax = new Vector2(_screenSafeArea.xMax - Screen.width,
            -_screenSafeArea.yMin);

        rectTransform.offsetMin = offsetMin;
        rectTransform.offsetMax = offsetMax;
    }
}

