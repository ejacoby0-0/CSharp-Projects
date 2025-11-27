using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static LibrarySystem.Methods;

namespace LibrarySystem
{
    internal class Methods
    {
        //Creating the book class with their respective propertise
        public class q1_Books
        {
            public string Title;
            public string Author;
            public int Year;

            //The constructure ensures that objects are properly set up and ready for use as soon as they are created.
            public q1_Books(string title, string author, int year)
            {
                Title = title;
                Author = author;
                Year = year;
            }
        }

        //Declaring AVL Tree
        static public q1_AVLTree bookTree = new q1_AVLTree();

        //Declaring the List collection to store the book data
        static public List<q1_Books> bookRecords = new List<q1_Books>();

        //The Book sample data
        public static void SampleBooks()
        {

            //Creating a new object for the book class to have data & assign data
            bookRecords = new List<q1_Books>
            {

                new q1_Books("The Silent Patient", "Alex Michaelides", 2019),

                new q1_Books("The Great Gatsby", "F. Scott Fitzgerald", 1925),

                new q1_Books("To Kill a Mockingbird", "Harper Lee", 1960),

                new q1_Books("1984", "George Orwell", 1949),

                new q1_Books("The Catcher in the Rye", "J.D. Salinger", 1951),

                new q1_Books("Pride and Prejudice", "Jane Austen", 1813),

                new q1_Books("Moby-Dick", "Herman Melville", 1851),

                new q1_Books("The Hobbit", "J.R.R. Tolkien", 1937),

                new q1_Books("Brave New World", "Aldous Huxley", 1932),

                new q1_Books("The Book Thief", "Markus Zusak", 2005),

                new q1_Books("The Road", "Cormac McCarthy", 2006),

                new q1_Books("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", 1997),

                new q1_Books("The Girl with the Dragon Tattoo", "Stieg Larsson", 2005),

                new q1_Books("The Alchemist", "Paulo Coelho", 1988),

                new q1_Books("The Shining", "Stephen King", 1977),

                new q1_Books("Wuthering Heights", "Emily Brontë", 1847),

                new q1_Books("Catch-22", "Joseph Heller", 1961),

                new q1_Books("The Hunger Games", "Suzanne Collins", 2008),

                new q1_Books("The Da Vinci Code", "Dan Brown", 2003),

                new q1_Books("The Outsiders", "S.E. Hinton", 1967)


            };


            // Insert each book into the AVL tree
            foreach (var book in bookRecords)
            {
                bookTree.Root = bookTree.Insert(bookTree.Root, book);
            }


        }

        

        //1. Displaying the books in order
        public static void q2_InOrderDisplay()
        {
            Console.WriteLine("\nBooks sorted by Title:");
            bookTree.q2_InOrderTraversal(bookTree.Root);

        }

        //2. Search for book based on year
        public static void q2_SearchByYear()
        {

            Console.Write("\nEnter the year of the book you want to search for: ");

            //Reads the users input and turns it into a int, however if a user uses letter it will be invalid
            if (!int.TryParse(Console.ReadLine(), out int searchYear))
            {
                Console.WriteLine("Invalid year entered (Please use numeric values)");
                return;
            }

            // This searches through all the data stored in the list (bookRecords) and create a new list (foundBooks)

            // Use AVL tree to search
            q1_Books foundBook = bookTree.q2_SearchByYear(bookTree.Root, searchYear);


            //If the books (foundBooks) count is greater than 0, is will display the book based on its year
            if (foundBook != null)
            {
                Console.WriteLine($"\nBooks published in {searchYear}:");
                Console.WriteLine($"Title: {foundBook.Title}, Author: {foundBook.Author}");
            }

            //Else if the books (foundBooks) count is less than 0, there is no book based on the year
            else
            {
                Console.WriteLine("\nNo books found for that year.");
            }
        }



        //3. Display the most recent book
        public static void q2_MostRecentBookDisplay()
        {
            //If there are no books, if won't display
            if (bookRecords.Count == 0)
            {
                Console.WriteLine("No books found.");
                return;
            }

            //Initalizing the maxyear and recent books
            int maxYear = int.MinValue;
            q1_Books recentBook = null;

            foreach (var books in bookRecords)
            {
                //if the books stored in the list is geater than maxyear, it will be the recent book
                if (books.Year > maxYear)
                {
                    maxYear = books.Year;
                    recentBook = books;
                }
            }

            //Displaying recent book based on year greater then the pervious books years
            Console.WriteLine($"\nMost recent book:");
            Console.WriteLine($"Title: {recentBook.Title}, Author: {recentBook.Author}, Year: {recentBook.Year}");


        }

        //4. Display the number of books
        public static void q2_NumberOfBooksDisplayed()
        {
            //The data that has been add or stored in the list, will be count by the Count method
            Console.WriteLine($"\nNumber of books in the library: {bookRecords.Count}");

        }





        //---------------------------AVL Tree----------------------------

        //Uses the book class and is used in the tree
        public class q1_Node
        {
            public q1_Books Data;
            public q1_Node Left;
            public q1_Node Right;
            public int Height;

            public q1_Node(q1_Books books)
            {
                Data = books;
                Height = 1; // a new node starts with a height of level 1
            }
        }


        //This AVL Tree uses the whole tree from the top of the node being the root of the tree
        public class q1_AVLTree
        {
            public q1_Node Root;

            //The height is a helper, that returens 0 if the node is empty
            private int Height(q1_Node node)
            {
                if (node == null)
                {
                    return 0;
                }
                else
                {
                    return node.Height;
                }

            }

            //The GetBalance is a helper, that returns the difference in height between the left and right subtree, using the balance factor formula
            private int GetBalance(q1_Node node)
            {
                if (node == null)
                {
                    return 0;
                }
                else
                {
                    return Height(node.Left) - Height(node.Right);
                }

            }

            //The RotateRight is a helper that moves the left child up and the currant node down to the right. Making sure to fix any imbalances if the left subtree is imbalance.
            private q1_Node RotateRight(q1_Node y)
            {
                q1_Node x = y.Left;
                q1_Node T2 = x.Right;

                // Rotate / adjust
                x.Right = y;
                y.Left = T2;

                // Update heights
                y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;
                x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;

                Console.WriteLine("Right Rotation");
                return x;
            }

            //The RotateLeft is a helper that moves the right child up and the currant node down to the left. Making sure to fix any imbalances if the right subtree is imbalance.
            private q1_Node RotateLeft(q1_Node x)
            {
                q1_Node y = x.Right;
                q1_Node T2 = y.Left;

                // Rotate / adjust
                y.Left = x;
                x.Right = T2;

                // Update heights
                x.Height = Math.Max(Height(x.Left), Height(x.Right)) + 1;
                y.Height = Math.Max(Height(y.Left), Height(y.Right)) + 1;

                Console.WriteLine("Left Rotation.");
                return y;
            }

            //The insert method determine based on the year which subtree it goes to
            public q1_Node Insert(q1_Node node, q1_Books books)
            {
                // 1. Regular BST insertion
                if (node == null)
                {
                    Console.WriteLine($"Inserting: {books.Title} {books.Author} ({books.Year})");

                    return new q1_Node(books);
                }

                if (books.Year < node.Data.Year)                        // The left child contains books with a year earlier than the parent 
                {                                                       
                    node.Left = Insert(node.Left, books);
                }
                else if (books.Year > node.Data.Year)                   // The right child contains books with a year later than the parent
                {
                    node.Right = Insert(node.Right, books);
                }
                else
                {
                    Console.WriteLine($"Duplicate year {books.Year} has been ignored");
                    return node;
                }

                // 2. Update height
                node.Height = 1 + Math.Max(Height(node.Left), Height(node.Right));

                // 3. Get balance factor
                int balance = GetBalance(node);

                // 4. Check for imbalances 
                if (balance > 1 && books.Year < node.Left.Data.Year)
                {
                    Console.WriteLine("Left-Left Case detected.");
                    return RotateRight(node);
                }

                // i.e. right subtree is taller than the left (right-heavy)
                if (balance < -1 && books.Year > node.Right.Data.Year)
                {
                    Console.WriteLine("Right-Right Case detected.");
                    return RotateLeft(node);
                }

                if (balance > 1 && books.Year > node.Left.Data.Year)
                {
                    Console.WriteLine("Left-Right Case detected.");
                    node.Left = RotateLeft(node.Left);
                    return RotateRight(node);
                }

                if (balance < -1 && books.Year < node.Right.Data.Year)
                {
                    Console.WriteLine("Right-Left Case detected.");
                    node.Right = RotateRight(node.Right);
                    return RotateLeft(node);
                }

                return node;
            }


            //1. AVL tree reflecting in-order travel
            public void q2_InOrderTraversal(q1_Node node)
            {
                if (node == null)
                    return;
                q2_InOrderTraversal(node.Left);
                Console.WriteLine($"Title: {node.Data.Title}, Author: {node.Data.Author}, Year: {node.Data.Year}");
                q2_InOrderTraversal(node.Right);
            }


            //2. AVL tree reflecting SearchByYear
            public q1_Books q2_SearchByYear(q1_Node node, int year)
            {
                if (node == null)
                    return null;
                if (year == node.Data.Year)
                    return node.Data;
                if (year < node.Data.Year)
                    return q2_SearchByYear(node.Left, year);
                else
                    return q2_SearchByYear(node.Right, year);
            }
        }
    }
}
