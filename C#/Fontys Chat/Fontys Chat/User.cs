// user classe.

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class User
    {
        private int id;

        private string name;

        private string email;

        private Chat currentChat;

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        /// <param name="email">The email.</param>
        public User(int id, string name, string email)
        {
            this.id = id;
            this.name = name;
            this.email = email;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id
        {
            get
            {
                return this.id;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets the email.
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }
        }

        /// <summary>
        /// Gets or sets the current chat.
        /// </summary>
        /// <value>
        /// The current chat.
        /// </value>
        public Chat CurrentChat
        {
            get
            {
                return this.currentChat;
            }
            set
            {
                this.currentChat = value;
            }
        }
        /// <summary>
        /// Adds the friend.
        /// </summary>
        /// <param name="friendId">The friend id.</param>
        public void AddFriend(int friendId)
        {
            DatabaseMethods.AddFriend(this.id, friendId);
        }

        /// <summary>
        /// Submits the text.
        /// </summary>
        /// <param name="text">The text.</param>
        public void SubmitText(string text)
        {
            this.currentChat.AddText(this.id, text);
        }
    }
}