using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHolder : MonoBehaviour
{
    [SerializeField] private GameObject[] objects;

    private GameObject activeObject = null;

    public void ActivateObject(int _index)
    {
        if (_index < 0 || _index >= objects.Length) return;

        for(int i = 0; i < objects.Length; i++)
            objects[i].SetActive((i == _index));

        activeObject = objects[_index];
    }

    public void InactiveAll()
    {
        for (int i = 0; i < objects.Length; i++)
            objects[i].SetActive(false);

        activeObject = null;
    }

    public GameObject GetActiveObject()
    {
        return activeObject;
    }
}
