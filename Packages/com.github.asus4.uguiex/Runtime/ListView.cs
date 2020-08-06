using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Unity.UI.Ex
{
    public class ListView<T> : UIBehaviour where T : Component, IListItem<T>
    {
        [System.Serializable]
        public class SelectEvent : UnityEvent<T> { }

        [SerializeField] protected GameObject prefab = null;
        [SerializeField] protected ScrollRect scrollRect;
        [SerializeField] protected bool hideTemplate = true;
        public SelectEvent onSelect = new SelectEvent();

        public List<GameObject> Items { get; private set; }

        protected override void OnEnable()
        {
            base.OnEnable();

            Items = GetChildren(scrollRect.content)
                        .Where(o => o.GetComponentInChildren<T>())
                        .ToList();
            foreach (var item in Items)
            {
                item.GetComponentInChildren<T>().OnClick += OnClickItem;
            }

            if (hideTemplate && Application.isPlaying)
            {
                RemoveAll();
            }
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            foreach (var item in Items)
            {
                item.GetComponentInChildren<T>().OnClick -= OnClickItem;
            }
        }

        protected virtual void OnClickItem(T item)
        {
            onSelect.Invoke(item);
        }

        public virtual GameObject Append()
        {
            var item = Instantiate(prefab);
            Append(item);
            return item;
        }

        public virtual void Append(GameObject item)
        {
            item.transform.SetParent(scrollRect.content, false);
            item.transform.SetAsLastSibling();
            item.GetComponentInChildren<T>().OnClick += OnClickItem;
            Items.Add(item);

            StartCoroutine(AfterAppend());
        }

        private IEnumerator AfterAppend()
        {
            yield return null;
            // Scroll to end
            scrollRect.horizontalNormalizedPosition = 1f;
        }

        public virtual void Remove(GameObject item)
        {
            item.GetComponentInChildren<T>().OnClick -= OnClickItem;
            Items.Remove(item);
            Destroy(item.gameObject);
        }

        public virtual T Remove(int index)
        {
            var item = Items[index];
            Remove(item);
            return item.GetComponentInChildren<T>();
        }

        public virtual void RemoveAll()
        {
            var tmpItems = new List<GameObject>(Items);
            foreach (var item in tmpItems)
            {
                Remove(item);
            }
        }

        public GameObject this[int index] => Items[index];

        private static List<GameObject> GetChildren(Transform t)
        {
            var children = new List<GameObject>();
            foreach (Transform child in t)
            {
                children.Add(child.gameObject);
            }
            return children;
        }
    }
}
