using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    ActiveItem,
    PassiveItem
}
public class ItemBase : MonoBehaviour
{
    
    [Header("���ܷ���")]
    public ItemType m_Itemtype;

    [Header("��������ʹ�ô���")]
    [Tooltip("����m_Itemtype=ActiveItemʱ������Ч")]
    public int m_UsageCount;

    [Header("ʰȡ�뾶")]
    public float m_PickDistance;

    private BoxCollider2D boxCollider;

    private ItemManager manager_Item;

    public ItemManager Manager_Item
    {
        set { manager_Item = value; }
    }


    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider2D>();

        manager_Item = GameObject.Find("ItemManager").GetComponent<ItemManager>();
        //boxCollider.size = new Vector3(m_PickDistance, m_PickDistance, m_PickDistance);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(coll.tag == "Player")
        {
            manager_Item.ItemDestroy(gameObject);
        }
    }
}
