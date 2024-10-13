using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScaleLoop : MonoBehaviour
{
    [SerializeField] private Image imageToScale;
    private float scaleDuration = 1f;
    private float minScale = 0.8f;
    [SerializeField] private float maxScale = 1.2f; 

    void Start()
    {
        if (imageToScale != null)
        {
            // Scale up and down in a loop
            imageToScale.transform.DOScale(maxScale, scaleDuration)
                .SetLoops(-1, LoopType.Yoyo)
                .SetEase(Ease.InOutSine);
        }
    }
}