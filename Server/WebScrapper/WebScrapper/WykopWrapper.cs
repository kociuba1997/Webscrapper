﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebScrapper
{
    class WykopWrapper : Wrapper
    {
  

        private string htmlMessageNode = ".//div/div/div[2]/p";
        private string htmlUsereNode = ".//div/div/div[1]/a[1]/b";
        private string htmlPhotoNode = ".//div/div/div[2]/div[1]/a";
        private string htmlUsertLink = ".//div/div/div[1]/a[1]";
        private string htmlTargetLink = ".//div/div/div[1]/a[2]";
        private string htlmStarting = "//*[@id=\"itemsStream\"]/li";

        public List<Wrapper> wrapperList = new List<Wrapper>();

        public WykopWrapper(string link) : base(link) 
        {
        }


        public string getUser(HtmlNode userNode)
        {
            try
            {
                userNode = userNode.SelectSingleNode(htmlUsereNode);
                user = encoder(userNode.InnerText);
            }
            catch (Exception ex)
            {
                return null;
            }

            return user;
        }

        public string getMessage(HtmlNode messageNode)
        {
            try
            {
                messageNode = messageNode.SelectSingleNode(htmlMessageNode);
                message = encoder(messageNode.InnerText);
            }
            catch (Exception ex)
            {
                return null;
            }
            return message;

        }

        public string getTargetLink(HtmlNode targetLinkNode)
        {
            try
            {
                // problem z zastępowaniem targetLinku tytułem wiadomosci
                targetLinkNode = targetLinkNode.SelectSingleNode(htmlTargetLink);
                HtmlAttribute attribute = targetLinkNode.Attributes["href"];
                targetLink = attribute.Value;
            }
            catch (Exception ex)
            {
                return null;
            }
            return targetLink;

        }

        public string getPhoto(HtmlNode photoNode)
        {
            try
            {
                // problem z zastępowaniem targetLinku tytułem wiadomosci
                photoNode = photoNode.SelectSingleNode(htmlPhotoNode);
                HtmlAttribute attribute = photoNode.Attributes["href"];
                photo = attribute.Value;
            }
            catch (Exception ex)
            {
                return null;
            }
            return photo;

        }


        public void getItterator()
        {
           
            foreach (HtmlNode li in htmlPageDoc.DocumentNode.SelectNodes(htlmStarting))
            {
                Wrapper post = new Wrapper();

                try
                {
                    post.user = getUser(li);

                    post.message = getMessage(li);

                    post.targetLink = getTargetLink(li);

                    post.photo = getPhoto(li);

                    wrapperList.Add(post);

                }
                catch
                {
                   
                }
                
            }
        }
    }
}
