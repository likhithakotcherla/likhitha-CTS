using System;
using System.Collections.Generic;
using Com.Cognizant.MovieCruiser.Model;
using Com.Cognizant.MovieCruiser.Dao;


namespace finalcheck
{
    class program
    {
        static void Main()
        {
            List<Movie> movielist = new List<Movie>();
            Admin admin = new Admin();
            Customer customer = new Customer();
            Dictionary<int, Customer> customerlist = new Dictionary<int, Customer>()
            {
                {1, new Customer(1,"likhitha") },
                {2, new Customer(2,"neha") }

            };
        Selectuser:
            Console.WriteLine("Enter 1 to login as admin or any other number to login as customer");
            int i = Convert.ToInt16(Console.ReadLine());
            if (i == 1)
            {
            AdminLogin:
                Console.WriteLine("Enter username for admin");
                admin.adminid = Console.ReadLine();
                Console.WriteLine("Enter name of admin");
                admin.adminName = Console.ReadLine();
                if ((admin.adminid == "likhitha") && (admin.adminName == "nithya"))
                {
                    Console.WriteLine("Logged in Sucessfully as Admin");
                AdminOptions:
                    Console.WriteLine("Enter 1 to view movielist ,2 to edit movie,3 to change usertype and 0 to Exit");
                    int c = Convert.ToByte(Console.ReadLine());
                    if (c == 3)
                    {
                        goto Selectuser;
                    }
                    if (c == 1)
                    {

                        admin.DisplayMovieListByAdmin();

                    }
                    if (c == 2)
                    {
                        Console.WriteLine("Enter the record id you want to edit");
                        int k = Convert.ToInt32(Console.ReadLine());
                        admin.EditMovie(k);
                        Console.WriteLine("Movie record updated succesfully");
                    }
                    if (c == 0)
                    {
                        Environment.Exit(1);
                    }
                    goto AdminOptions;
                }
                else
                {
                    Console.WriteLine("Invalid Credentials");
                    goto AdminLogin;
                }
            }
            else
            {
                goto Customer;
            }
        Customer:
            Console.WriteLine("Enter username for customer");
            customer.customerId = Convert.ToByte(Console.ReadLine());
            Console.WriteLine("Enter name of customer");
            customer.customerName = Console.ReadLine();
            if (customer.customerId == customerlist[customer.customerId].customerId && customer.customerName == customerlist[customer.customerId].customerName)
            {
                Console.WriteLine("Loged in as Customer");
                Console.WriteLine("MovieList is: \n");
                customer.DisplayMovieListByCustomer();
                List<Movie> favorites = new List<Movie>();
                favorites.Add(new Movie(1, "Avatar", "$2,787,965,087", "Yes", "15/03/2017", "Science Fiction", "Yes"));
                favorites.Add(new Movie(2, "The Avengers", "$1,518,812,988", "Yes", "23/12/2017", "Superhero", "No"));
                Console.WriteLine("Enter an id from movielist to add to favorites");
                int m = Convert.ToInt16(Console.ReadLine());
                if (m > 3)
                {
                    Console.WriteLine("Selected MovieId Not in the list");
                }
                else
                    customer.AddToFavorites(m,favorites);
                Console.WriteLine("Enter id in favorites of specified movie to delete from favorites");
                int n = Convert.ToInt16(Console.ReadLine());
                customer.RemoveFavorites(n, favorites);
            }
            else
                Console.WriteLine("Invalid Customer credentials");
        }
    }
}