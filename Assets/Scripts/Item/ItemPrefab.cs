using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public enum ItemType
{
    ActiveItem,
    PassiveItem
}
public enum ItemName
{
    Others,
    GoldenSilk
}

namespace Com.Tencent.DYYS
{
    public class ItemPrefab : MonoBehaviourPun
    {

        [Header("���ܷ���")]
        public ItemType Itemtype;

        [Header("��������ʹ�ô���")]
        [Tooltip("����m_Itemtype=ActiveItemʱ������Ч")]
        public int UsageCount;

        [Header("ʰȡ�뾶")]
        public float PickDistance;

        [Header("UI��Դ")]
        public Sprite UItexture;

        [Header("������Դ")]
        public AudioClip AudioClip;

        public ItemName ItemName;

        private BoxCollider m_boxCollider;

        private ItemManager manager_Item;

        public ItemManager Manager_Item
        {
            set { manager_Item = value; }
        }

        // Start is called before the first frame update
        void Start()
        {
            m_boxCollider = gameObject.GetComponent<BoxCollider>();

            m_boxCollider.size = new Vector3(PickDistance, PickDistance, PickDistance);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
