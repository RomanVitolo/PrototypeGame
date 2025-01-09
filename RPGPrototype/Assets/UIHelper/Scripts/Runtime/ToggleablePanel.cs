using System;
using UnityEngine;
using UnityEngine.UI;

namespace UIHelper.Scripts.Runtime
{
    public class ToggleablePanel : MonoBehaviour
    {
        [SerializeField] protected Button _closeButton;
        CanvasGroup _canvasGroup;

        protected void Awake()
        {
            _closeButton.onClick.AddListener(HideCanvas);
            _canvasGroup = GetComponent<CanvasGroup>();
            HideCanvas();
        } 
        
        protected void ShowCanvas()
        {
            _canvasGroup.alpha = 0.5f;
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        }
        
        protected void HideCanvas()
        {
            _canvasGroup.alpha = 0f;
            _canvasGroup.interactable = false;
            _canvasGroup.blocksRaycasts = false;
        }

        private void OnDestroy()
        {
            _closeButton.onClick.RemoveAllListeners();
        }
    }
}