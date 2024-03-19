using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 startTouchPosition;
    private Vector2 currentSwipe;
    [SerializeField] private MenuCategory menuCategory;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startTouchPosition = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // While dragging, we update the current swipe direction
        currentSwipe = eventData.position - startTouchPosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Determine if the swipe is predominantly horizontal
        if (Mathf.Abs(currentSwipe.x) > Mathf.Abs(currentSwipe.y))
        {
            if (currentSwipe.x > 0)
            {
                // Swipe right
                MoveToPreviousPage();
            }
            else
            {
                // Swipe left
                MoveToNextPage();
            }
        }
        // Reset currentSwipe for the next swipe gesture
        currentSwipe = Vector2.zero;
    }

    void MoveToNextPage()
    {
        // Implement your logic to move to the next page
        Debug.Log("Moving to next page");
        MenuManager.Instance.MoveToNextTab();
    }

    void MoveToPreviousPage()
    {
        // Implement your logic to move to the previous page
        Debug.Log("Moving to previous page");
        MenuManager.Instance.MoveToPreviousTab();
    }
}