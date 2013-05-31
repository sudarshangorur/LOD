using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;

namespace Application
{
    public class YouTubeWebService
    {
        public static List<string> YouTubeChannelsList()
        {
            WebRequest request = WebRequest.Create("https://gdata.youtube.com/feeds/api/channels?v=2");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(dataStream);
            XmlNodeList xmlNodeList = xmlDoc.GetElementsByTagName("title");
            List<string> youTubeChannelsList = new List<string>();
            for (int i = 0; i < xmlNodeList.Count; i++)
            {
                youTubeChannelsList.Add(xmlNodeList[i].InnerText);
            }
            return youTubeChannelsList;
        }

        
        public static List<string> YouTubeTopRatedVideosList()
        {
            var request = WebRequest.Create("https://gdata.youtube.com/feeds/api/standardfeeds/top_rated");
            request.Method = "GET";
            var response = request.GetResponse();
            var dataStream = response.GetResponseStream();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(dataStream);
            var xmlNodeList = xmlDoc.GetElementsByTagName("title");
            var youTubeTopRatedVideosList = new List<string>();
            for (var i = 0; i < xmlNodeList.Count; i++)
            {
                youTubeTopRatedVideosList.Add(xmlNodeList[i].InnerText);
            }
            return youTubeTopRatedVideosList;
        }
    }
}