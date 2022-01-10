using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Item",menuName = "Assets/item")]
public class Item : ScriptableObject
{
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public Dictionary<string, int> stats = new Dictionary<string, int>();
    private int v1;
    private string v2;
    private string v3;
    private Dictionary<string, int> dictionary;

    public Item(int id, string title, string description, Sprite icon, Dictionary<string, int> stats)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.icon = icon;
        this.stats = stats;
    }
    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.icon = item.icon;
        this.stats = item.stats;
    }

    public Item(int v1, string v2, string v3, Dictionary<string, int> dictionary)
    {
        this.v1 = v1;
        this.v2 = v2;
        this.v3 = v3;
        this.dictionary = dictionary;
    }

    public static implicit operator Item(GameObject v)
    {
        throw new NotImplementedException();
    }
}