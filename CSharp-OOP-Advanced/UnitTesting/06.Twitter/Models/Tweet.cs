using System;
using System.Collections.Generic;
using System.Text;
using _06.Twitter.Contracts;

namespace _06.Twitter.Models
{
    public class Tweet : ITweet
    {
        private string message;

        public Tweet(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentException("Invalid message!");
            }

            this.message = message;
        }

        public string RetrieveMessage()
        {
            return this.message;
        }
    }
}
