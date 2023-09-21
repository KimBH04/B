using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Slot[] slots;

    private Vector3 _target;
    private ItemInfo carryingItem;

    private Dictionary<int, Slot> slotDictionary;

    void Start()
    {
        slotDictionary = new Dictionary<int, Slot>();

        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].id = i;
            slotDictionary.Add(i, slots[i]);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SendRayCast();
        }

        if (Input.GetMouseButton(0) && carryingItem)
        {
            OnItemSelected();
        }

        if (Input.GetMouseButtonUp(0))
        {
            SendRayCast();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceRandomItem();
        }
    }

    void SendRayCast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var slot = hit.transform.GetComponent<Slot>();
            if (slot.state == Slot.SLOTSTATE.FULL && carryingItem == null)
            {
                string itemPath = "Prefabs/Item_Grabbed_" + slot.itemObject.id.ToString("000");
                var iteGO = (GameObject)Instantiate(Resources.Load(itemPath));
                iteGO.transform.position = slot.transform.position;
                iteGO.transform.localScale = Vector3.one * 1.2f;

                carryingItem = iteGO.GetComponent<ItemInfo>();
                carryingItem.InitDummy(slot.id, slot.itemObject.id);

                slot.ItemGrabbed();
            }
            else if (slot.state == Slot.SLOTSTATE.EMPTY && carryingItem != null)
            {
                slot.CreateItem(carryingItem.itemId);
                Destroy(carryingItem.gameObject);
            }
            else if (slot.state == Slot.SLOTSTATE.FULL && carryingItem != null)
            {
                if (slot.itemObject.id == carryingItem.itemId)
                {
                    OnItemMergedWithTarget(slot.id);
                }
                else
                {
                    OnItemCarryFail();
                }
            }
        }
        else
        {
            if (!carryingItem)
            {
                return;
            }
            OnItemCarryFail();
        }
    }

    void OnItemSelected()
    {
        _target = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 3));
        _target.z = 0;
        Debug.Log(_target.ToString());

        var delta = 10 * Time.deltaTime;

        delta *= Vector3.Distance(transform.position, _target);
        carryingItem.transform.position = Vector3.MoveTowards(carryingItem.transform.position, _target, delta);
    }

    void OnItemMergedWithTarget(int targetSlotId)
    {
        var slot = GetSlotById(targetSlotId);
        Destroy(slot.itemObject.gameObject);
        slot.CreateItem(carryingItem.itemId + 1);
        Destroy(carryingItem.gameObject);
    }

    void OnItemCarryFail()
    {
        var slot = GetSlotById(carryingItem.slotId);
        slot.CreateItem(carryingItem.itemId);
        Destroy(carryingItem.gameObject);
    }

    void PlaceRandomItem()
    {
        if (AllSlotsOccupied())
        {
            Debug.LogWarning("Slot is full => Can't instantinate");
            return;
        }

        Slot slot;
        do
        {
            var rand = Random.Range(0, slots.Length);
            slot = GetSlotById(rand);
        }
        while (slot.state == Slot.SLOTSTATE.FULL);

        slot.CreateItem(0);
    }

    bool AllSlotsOccupied()
    {
        foreach (var slot in slots)
        {
            if (slot.state == Slot.SLOTSTATE.EMPTY)
            {
                return false;
            }
        }

        return true;
    }

    Slot GetSlotById(int id)
    {
        return slotDictionary[id];
    }
}
