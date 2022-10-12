using System.Xml;
using System.Xml.Serialization;

namespace Homework
{
    public class StatisticService : IStatisticService
    {
        XmlDocument document;

        public StatisticService()
        {
            if (!File.Exists("statistic.xml"))
            {
                CreateFile();
            }
            document = new XmlDocument();
            document.Load("statistic.xml");
        }

        private void CreateFile()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.NewLineOnAttributes = true;
            using (XmlWriter writer = XmlWriter.Create("statistic.xml", settings))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("statistics");
                writer.WriteEndElement();
                writer.WriteEndDocument();
                writer.Flush();
                writer.Close();
            }
        }

        public void Add(Statistic item)
        {
            var root = document.DocumentElement;

            #region OldCode
            //XmlElement itemElement = document.CreateElement("item");
            //XmlElement dateElement = document.CreateElement("date");
            //XmlElement trueCount = document.CreateElement("truecount");
            //XmlElement falseCount = document.CreateElement("falsecount");

            //XmlText dateText = document.CreateTextNode(item.date.ToString());
            //XmlText trueText = document.CreateTextNode(item.trueAnswersCount.ToString());
            //XmlText falseText = document.CreateTextNode(item.falseAnswersCount.ToString());

            //dateElement.AppendChild(dateText);
            //trueCount.AppendChild(trueText);
            //falseCount.AppendChild(falseText);

            //itemElement.AppendChild(dateElement);
            //itemElement.AppendChild(trueCount);
            //itemElement.AppendChild(falseCount);

            //root.AppendChild(itemElement);

            #endregion
            var nav = root.CreateNavigator();
            using (var writer = nav.AppendChild())
            {
                writer.WriteComment("");
                var serializer = new XmlSerializer(item.GetType());
                serializer.Serialize(writer, item);
                writer.Close();
            }
            document.Save("statistic.xml");
        }

        public List<Statistic> GetStatistic()
        {
            List<Statistic> list = new List<Statistic>();
            XmlReader reader = new XmlNodeReader(document);
            var deserializer = new XmlSerializer(typeof(List<Statistic>), new XmlRootAttribute("statistics"));
            list = (List<Statistic>)deserializer.Deserialize(reader);
            ;
            return list;
        }

    }
}
