using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InfnityScrollLimited : UIBehaviour, InfinityScrollSetUp

{
    [SerializeField]
    public int max = 0;

    public void OnPostSetupItems()
    {
        var infiniteScroll = GetComponent<InfinityScoll>();
        infiniteScroll.onUpdateItem.AddListener(OnUpdateItem);
        //GetComponentInParent<ScrollRect>().movementType = ScrollRect.MovementType.Elastic;
        var rectTransform = GetComponent<RectTransform>();
        var delta = rectTransform.sizeDelta;

        //横サイズを増加。縦方向ならyで
        delta.x = infiniteScroll.itemScale * max;
        rectTransform.sizeDelta = delta;


    }

    public void OnUpdateItem(int itemCount, GameObject obj)
    {
        if (itemCount < 0 || itemCount >= max)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);

            //対象のゲームオブジェクトに付属したItemを呼び出す
            var item = obj.GetComponentInChildren<ChatSortNumber>();
            item.UpdateChat(itemCount);
        }
    }
}
