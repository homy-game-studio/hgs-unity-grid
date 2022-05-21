using System.Collections.Generic;
using UnityEngine;

namespace HGS.Grid
{
  [CreateAssetMenu(fileName = "GridMap", menuName = "HGS/Grid/GridMap")]
  public class GridMap : ScriptableObject
  {
    public class Storage
    {
      Dictionary<string, GameObject> hashmap = new Dictionary<string, GameObject>();

      public bool ContainsKey(string key)
      {
        return hashmap.ContainsKey(key);
      }

      public bool IsEmpty(string key)
      {
        // Uma  coordenada está  vazia,  quando  não  há itens armazenados
        return !ContainsKey(key);
      }

      public GameObject Get(string key)
      {
        if (!ContainsKey(key)) throw new System.Exception($"Failed to get: Coord '{key}' not found in GridMap");
        return hashmap[key];
      }

      public void Add(string key, GameObject obj)
      {
        if (ContainsKey(key)) throw new System.Exception($"Failed to add: Coord '{key}' already occupied");
        hashmap.Add(key, obj);
      }

      public void Remove(string key)
      {
        if (!ContainsKey(key)) throw new System.Exception($"Failed to remove: Coord '{key}' not found in GridMap");
        hashmap.Remove(key);
      }

      public void Clear()
      {
        hashmap.Clear();
      }
    }

    [SerializeField] GridBase grid = null;

    Storage storage = new Storage();

    private string ParseKey(Vector3Int coord)
    {
      return coord.ToString();
    }

    public bool ContainsCoord(Vector3Int coord)
    {
      return storage.ContainsKey(ParseKey(coord));
    }

    public bool IsEmpty(Vector3Int coord)
    {
      return storage.IsEmpty(ParseKey(coord));
    }

    public void Add(Vector3Int coord, GameObject go)
    {
      storage.Add(ParseKey(coord), go);
    }

    public void Remove(Vector3Int coord)
    {
      storage.Remove(ParseKey(coord));
    }

    public GameObject Get(Vector3Int coord)
    {
      return storage.Get(ParseKey(coord));
    }

    public void Move(Vector3Int origin, Vector3Int destination)
    {
      if (ContainsCoord(destination)) throw new System.Exception($"Failed to move: '{destination}' already occupied");

      var item = Get(origin);

      Remove(origin);
      Add(destination, item);
    }

    public void Clear()
    {
      storage.Clear();
    }

    void OnEnable()
    {
      Clear();
    }
  }
}