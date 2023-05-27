using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ExampleEventTrigger : EventTrigger
{
    public Text My_text;

    public void Down()
    {
        My_text.text = "Down";
    }

    //public void BeginDrag(PointerEventData data)
    //{
    //    Debug.Log("OnBeginDrag called.");
    //}

    //public void Cancel(BaseEventData data)
    //{
    //    Debug.Log("OnCancel called.");
    //}

    //public void Deselect(BaseEventData data)
    //{
    //    Debug.Log("OnDeselect called.");
    //}

    //public void Drag(PointerEventData data)
    //{
    //    Debug.Log("OnDrag called.");
    //}

    //public void Drop(PointerEventData data)
    //{
    //    Debug.Log("OnDrop called.");
    //}

    //public void EndDrag(PointerEventData data)
    //{
    //    Debug.Log("OnEndDrag called.");
    //}

    //public void InitializePotentialDrag(PointerEventData data)
    //{
    //    Debug.Log("OnInitializePotentialDrag called.");
    //}

    //public void Move(AxisEventData data)
    //{
    //    Debug.Log("OnMove called.");
    //}

    //public void PointerClick(PointerEventData data)
    //{
    //    Debug.Log("OnPointerClick called.");
    //}

    //public void PointerDown(PointerEventData data)
    //{
    //    Debug.Log("OnPointerDown called.");
    //}

    //public void PointerEnter(PointerEventData data)
    //{
    //    Debug.Log("OnPointerEnter called.");
    //}

    //public void PointerExit(PointerEventData data)
    //{
    //    Debug.Log("OnPointerExit called.");
    //}

    //public void PointerUp(PointerEventData data)
    //{
    //    Debug.Log("OnPointerUp called.");
    //}

    //public void Scroll(PointerEventData data)
    //{
    //    Debug.Log("OnScroll called.");
    //}

    //public void Select(BaseEventData data)
    //{
    //    Debug.Log("OnSelect called.");
    //}

    //public void Submit(BaseEventData data)
    //{
    //    Debug.Log("OnSubmit called.");
    //}

    //public void UpdateSelected(BaseEventData data)
    //{
    //    Debug.Log("OnUpdateSelected called.");
    //}
}