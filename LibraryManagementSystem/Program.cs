﻿namespace LibraryManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            var testString = @"Book:
                    Author: Brian Jensen
                    Title: Texts from Denmark
                    Publisher: Gyldendal
                    Published: 2001
                    NumberOfPages: 253
                     
                    Book:
                    Author: Peter Jensen
                    Author: Hans Andersen
                    Title: Stories from abroad
                    Publisher: Borgen
                    Published: 2012
                    NumberOfPages: 156
                    ";

            Book.ReadBooks(testString);
            var result = Book.FindBooks("*Hans*");

        }
    }
}