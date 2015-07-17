// chat.

namespace WebApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class Chat
    {
        private string name;

        private int id;

        /// <summary>
        /// Initializes a new instance of the <see cref="Chat"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="name">The name.</param>
        public Chat(int id, string name)
        {
            this.id = id;
            this.name = name;
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
        }
        /// <summary>
        /// Adds the text.
        /// </summary>
        /// <param name="authorId">The author id.</param>
        /// <param name="text">The text.</param>
        public void AddText(int authorId, string text)
        {
            DatabaseMethods.AddChatText(authorId, text);
        } 
    }
}