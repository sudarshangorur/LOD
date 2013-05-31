using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using FluentAssertions;
using NUnit.Framework;


namespace Application.ScratchPad
{
    internal class ScratchPad
    {
        [Test]
        public XmlNodeList YouTubeChannelsList()
        {
            WebRequest request = WebRequest.Create("https://gdata.youtube.com/feeds/api/videos/vak9ZLfhGnQ?v=2");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(dataStream);
            XmlNodeList channelsInFeed = xmlDoc.GetElementsByTagName("title");
            for (int i = 0; i < channelsInFeed.Count; i++)
            {
                Console.WriteLine(channelsInFeed[i].InnerText);
            }

            return channelsInFeed;
        }

        [Test]
        public void YouTubeTopRatedVideosList()
        {
            WebRequest request = WebRequest.Create("https://gdata.youtube.com/feeds/api/standardfeeds/top_rated");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(dataStream);
            XmlNodeList topRatedVideosList = xmlDoc.GetElementsByTagName("title");
            for (int i = 0; i < topRatedVideosList.Count; i++)
            {
                Console.WriteLine(topRatedVideosList[i].InnerText);
            }
            Console.WriteLine(topRatedVideosList.Count);

        }

        [Test]
        public void YouTubeVideosList()
        {
            WebRequest request = WebRequest.Create("https://gdata.youtube.com/feeds/api/standardfeeds/top_rated");
            request.Method = "GET";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(dataStream);
            XmlNodeList topRatedVideosList = xmlDoc.GetElementsByTagName("title");
            List<string> videos = new List<string>();
            for (int i = 0; i < topRatedVideosList.Count; i++)
            {
                videos.Add(topRatedVideosList[i].InnerText);
            }

            videos.Contains("Adele - Rolling In The Deep").Should().BeTrue();
        }
    }
}