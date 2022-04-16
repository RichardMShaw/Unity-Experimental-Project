using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(menuName = "Project/System/Save System", order = 0)]
public class SaveSystem : ScriptableObject
{
  public void Save(object data, string filename = "player")
  {
    BinaryFormatter formatter = new BinaryFormatter();
    string path = Application.persistentDataPath + "/" + filename + ".dat";
    FileStream stream = new FileStream(path, FileMode.Create);

    formatter.Serialize(stream, data);
    stream.Close();
  }

  public object Load(string filename = "player")
  {
    string path = Application.persistentDataPath + "/" + filename + ".dat";
    if (File.Exists(path))
    {
      BinaryFormatter formatter = new BinaryFormatter();
      FileStream stream = new FileStream(path, FileMode.Open);
      object data = formatter.Deserialize(stream) as object;
      stream.Close();

      return data;
    }
    else
    {
      return null;
    }
  }
}
