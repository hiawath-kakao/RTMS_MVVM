using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Mdev.Common
{
    public static class Util
    {
        public static void SaveData<T>(string fileName, T dataToSave)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (TextWriter textWriter = new StreamWriter(fileName))
            {
                serializer.Serialize(textWriter, dataToSave);
                textWriter.Close();
            }
        }

        public static T ReadData<T>(string fileName)
        {
            if (File.Exists(fileName))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StreamReader reader = new StreamReader(fileName))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            return default;
        }

        public static T FindAncestor<T>(this DependencyObject obj)
where T : DependencyObject
        {
            DependencyObject tmp = VisualTreeHelper.GetParent(obj);
            while (tmp != null && !(tmp is T))
            {
                tmp = VisualTreeHelper.GetParent(tmp);
            }
            return tmp as T;
        }
    }
}
