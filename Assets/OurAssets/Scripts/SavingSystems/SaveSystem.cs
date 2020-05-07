using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
	public static void InitialSave(GameManager gm)
	{
		string path = Application.persistentDataPath + "/player.data";

		if (File.Exists(path))
		{
			Debug.Log("Save file found in " + path);
			gm.LoadPlayer();
		}
		else
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Create);

			GameManagerData data = new GameManagerData(gm);

			formatter.Serialize(stream, data);
			stream.Close();

			Debug.Log("Initial Player Save in " + path);
		}

	}

	public static void SaveGameManager(GameManager gm)
	{
		string path = Application.persistentDataPath + "/player.data";

		BinaryFormatter formatter = new BinaryFormatter();
		FileStream stream = new FileStream(path, FileMode.Create);

		GameManagerData data = new GameManagerData(gm);

		formatter.Serialize(stream, data);
		stream.Close();

		Debug.Log("Player Game saved");

	}


	public static GameManagerData LoadGameManager()
	{
		string path = Application.persistentDataPath + "/player.data";
		if (File.Exists(path))
		{
			BinaryFormatter formatter = new BinaryFormatter();
			FileStream stream = new FileStream(path, FileMode.Open);

			GameManagerData data = formatter.Deserialize(stream) as GameManagerData;
			stream.Close();

			Debug.Log("Save file loaded from " + path);

			return data;
		}
		else
		{
			Debug.Log("Save file not found has in " + path);
			return null;
		}

	}



}
