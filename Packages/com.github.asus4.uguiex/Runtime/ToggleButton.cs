using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Unity.UI.Ex
{

    [ExecuteAlways]
    [SelectionBase]
    [DisallowMultipleComponent]
    public class ToggleButton : Button
    {
        [SerializeField] bool _isOn;

        public bool isOn
        {
            get => _isOn;
            set
            {
                if (_isOn == value) return;
                _isOn = value;

                var state = value ? SelectionState.Selected : SelectionState.Normal;
                DoStateTransition(state, false);
            }
        }

        protected override void Start()
        {
            base.Start();
            var state = isOn ? SelectionState.Selected : SelectionState.Normal;
            DoStateTransition(state, true);
        }

#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            var state = isOn ? SelectionState.Selected : SelectionState.Normal;
            DoStateTransition(state, true);
        }
#endif // UNITY_EDITOR

        public override void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("onpointerclick");
            Toggle();
            onClick.Invoke();

        }

        public override void OnSubmit(BaseEventData eventData)
        {
            Debug.Log("OnSubmit");
            Toggle();
            onClick.Invoke();
        }

        public void Toggle()
        {
            if (!IsActive())
                return;
            isOn = !isOn;
        }

        protected override void DoStateTransition(SelectionState state, bool instant)
        {
            // Debug.Log($"DoStateTransition: {state}, {instant}");
            if (isOn)
            {
                if (state == SelectionState.Normal)
                {
                    state = SelectionState.Selected;
                }
            }
            else
            {
                if (state == SelectionState.Selected)
                {
                    state = SelectionState.Normal;
                }
            }
            base.DoStateTransition(state, instant);
        }
    }
}
