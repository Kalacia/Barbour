﻿namespace Library.Models
{
    public class Book
    {
        public string ISBN { get; set; }
        public string Title { get; set; }
        public string Author{ get; set; }
        public bool AvailabilityStatus { get; set; }
        public User CheckedOutBy { get; set; }
        public List<History> History { get; set; }

        public Book(string isbn) 
        {
            ISBN = isbn;
            History = new List<History>();
        }

        public Book() 
        {
            History = new List<History>();
        }

        public void CheckOut(User user)
        {
            var history = new History("CheckOut", user);
            History.Add(history);
            AvailabilityStatus = false;
            CheckedOutBy = user;
        }

        public void CheckIn(User user)
        {
            var history = new History("CheckIn", user);
            History.Add(history);
            AvailabilityStatus = true;
            CheckedOutBy = null;
        }
    }
}
