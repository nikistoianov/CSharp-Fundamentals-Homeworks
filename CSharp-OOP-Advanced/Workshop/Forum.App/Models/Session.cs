﻿namespace Forum.App.Models
{
	using Contracts;
	using DataModels;
    using System.Collections.Generic;
    using System.Linq;

    public class Session : ISession
	{
        private User user;
        private Stack<IMenu> history;

		public string Username => this.user?.Username;

		public int UserId => this.user?.Id ?? 0;

		public bool IsLoggedIn => this.user != null;

		public IMenu CurrentMenu => this.history.Peek();

        public Session()
        {
            this.history = new Stack<IMenu>();
        }

		public IMenu Back()
		{
            if (this.history.Count > 0)
            {
                this.history.Pop();
            }

            var previousMenu = this.history.Peek();
            previousMenu.Open();

            return previousMenu;
		}

		public void LogIn(User user)
		{
            this.user = user;
		}

		public void LogOut()
		{
            this.user = null;
        }

		public bool PushView(IMenu view)
		{
            if (this.history.Any() || this.history.Peek() != view)
            {
                this.history.Push(view);
                return true;
            }
            return false;
		}

		public void Reset()
		{
            this.history = new Stack<IMenu>();
            this.user = null;
        }
	}
}