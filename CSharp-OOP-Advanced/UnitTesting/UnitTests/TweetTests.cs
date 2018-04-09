using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Moq;
using NUnit.Framework;
using _06.Twitter.Contracts;
using _06.Twitter.Models;

namespace UnitTests
{
    public class TweetTests
    {
        [Test]
        public void InitializeTweetCorrectly()
        {
            string message = "This is a message.";
            Tweet tweet = new Tweet(message);
            FieldInfo field = typeof(Tweet).GetField("message", BindingFlags.NonPublic | BindingFlags.Instance);
            string value = (string)field.GetValue(tweet);

            Assert.That(value, Is.EqualTo(message));
        }

        [Test]
        public void TweetThrowsExceptionIfInitializedWithEmpyParameter()
        {
            Assert.That(() => new Tweet(""), Throws.ArgumentException.With.Message.EqualTo("Invalid message!"));
        }

        [Test]
        public void TweetThrowsExceptionIfInitializedWithNull()
        {
            Assert.That(() => new Tweet(null), Throws.ArgumentException.With.Message.EqualTo("Invalid message!"));
        }

        [Test]
        public void RetrieveMessageReturnsTheCorrectValue()
        {
            string message = "This is a message.";
            Tweet tweet = new Tweet(message);

            Assert.That(tweet.RetrieveMessage(), Is.EqualTo(message));
        }

        [Test]
        public void InitializesClientCorrectly()
        {
            Tweet tweet = new Tweet("This is a message.");
            Client client = new Client(tweet);
            FieldInfo field = typeof(Client).GetField("tweet", BindingFlags.NonPublic | BindingFlags.Instance);
            Tweet expectedTweet = (Tweet)field.GetValue(client);

            Assert.That(expectedTweet, Is.EqualTo(tweet));
        }

        [Test]
        public void ThrowsExceptionIfParameterIsNull()
        {
            Assert.That(() => new Client(null), Throws.ArgumentException.With.Message.EqualTo("Tweet cannot be null!"));
        }

        [Test]
        public void PrintMessageReturnsTheCorrectMessage()
        {
            Mock<ITweet> fakeTweet = new Mock<ITweet>();
            fakeTweet.Setup(m => m.RetrieveMessage()).Returns("This is a message.");
            Client client = new Client(fakeTweet.Object);

            client.PrintMessage();
        }
    }
}
