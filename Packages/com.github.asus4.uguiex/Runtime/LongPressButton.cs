using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Unity.UI.Ex
{
    public class LongPressButton : Button
    {
        [System.Serializable]
        public class LongPressEvent : UnityEvent<bool> { }

        [SerializeField, Range(0.1f, 3f)] float longPressTime = 1.5f;
        public LongPressEvent onLongPress = new LongPressEvent();


        Coroutine longtapCoroutine = null;
        bool _isLongPress = false;

        bool IsLongPress
        {
            get => _isLongPress;
            set
            {
                if (_isLongPress == value)
                {
                    return;
                }
                _isLongPress = value;
                onLongPress.Invoke(value);
            }
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            _isLongPress = false;
        }

        public override void OnPointerDown(PointerEventData eventData)
        {
            base.OnPointerEnter(eventData);
            // Debug.Log($"OnPointerEnter: {eventData}");

            IsLongPress = false;

            if (longtapCoroutine != null)
            {
                StopCoroutine(longtapCoroutine);
            }
            longtapCoroutine = StartCoroutine(StartLongPressCroutine());
        }

        public override void OnPointerUp(PointerEventData eventData)
        {
            base.OnPointerUp(eventData);

            if (longtapCoroutine != null)
            {
                StopCoroutine(longtapCoroutine);
                longtapCoroutine = null;
            }
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (IsLongPress)
            {
                return;
            }
            base.OnPointerClick(eventData);
        }

        public override void OnSubmit(BaseEventData eventData)
        {
            if (IsLongPress)
            {
                return;
            }
            base.OnSubmit(eventData);

        }

        private IEnumerator StartLongPressCroutine()
        {
            yield return new WaitForSecondsRealtime(longPressTime);
            IsLongPress = true;
        }

    }
}

