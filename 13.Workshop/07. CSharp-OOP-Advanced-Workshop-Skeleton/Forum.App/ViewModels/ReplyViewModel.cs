﻿namespace Forum.App.ViewModels
{
    using Contracts;
    using System.Collections.Generic;
    using System.Text;

    public class ReplyViewModel : ContentViewModel, IReplyViewModel
    {
        public ReplyViewModel(string author, string text) : base(text)
        {
            this.Author = author;
        }

        public string Author { get; }
    }
}
