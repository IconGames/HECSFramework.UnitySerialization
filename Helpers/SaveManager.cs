using System;
using System.IO;
using HECSFramework.Core;

namespace HECSFramework.Unity
{
    public partial class SaveManager
    {
        public static bool TryLoadFromFile(string path, out EntityResolver entityResolver)
        {
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                try
                {
                    var loadData = MessagePack.MessagePackSerializer.Deserialize<EntityResolver>(fs);

                    entityResolver = loadData;
                    return true;
                }
                catch (Exception ex)
                {
                    HECSDebug.LogError("our data corrupted" + ex.Message);
                }
                finally
                {
                    fs.Close();
                }
            }

            HECSDebug.Log("нет файла сохранения");
            entityResolver = default;
            return false;
        }

        public static bool TryLoadFromFile(string path, out byte[] data)
        {
            if (File.Exists(path))
            {
                FileStream fs = new FileStream(path, FileMode.Open);
                try
                {
                    var loadData = MessagePack.MessagePackSerializer.Deserialize<byte[]>(fs);

                    data = loadData;
                    return true;
                }
                catch (Exception ex)
                {
                    HECSDebug.LogError("our data corrupted" + ex.Message);
                }
                finally
                {
                    fs.Close();
                }
            }

            HECSDebug.Log("нет файла сохранения");
            data = default;
            return false;
        }
    }
}
