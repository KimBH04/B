using UnityEngine;

public class GenericContainerExample : MonoBehaviour
{
    private GenericContainer<int> intContainer;
    private GenericContainer<string> stringContainer;

    void Start()
    {
        intContainer = new(10);
        stringContainer = new(5);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            intContainer.Add(Random.Range(0, 100));
            DisplayContainerItems(intContainer);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            string ranStr = "Item " + Random.Range(0, 100);
            stringContainer.Add(ranStr);
            DisplayContainerItems(stringContainer);
        }
    }

    private void DisplayContainerItems<T>(GenericContainer<T> container)
    {
        T[] item = container.GetItems();
        string temp = string.Empty;

        for (int i = 0; i < item.Length; i++)
        {
            if (item[i] != null)
            {
                temp += item[i] + " / ";
            }
            else
            {
                temp += "Empty / ";
            }
        }

        Debug.Log(temp);
    }
}
