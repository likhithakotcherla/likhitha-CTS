using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Cognizant.MovieCruiser.Model;

namespace Com.Cognizant.MovieCruiser.Dao
{


    abstract public class User
    {
        public List<Movie> movieList = new List<Movie>()

                {
                new Movie(1, "Avathar", "$2,787,965,087", "Yes", "15/03/2017", "Science Fiction", "Yes"),
                new Movie(2, "The Avergers", "$1,518,812,988","Yes", "23/12/2017", "Superhero", "No"),
                new Movie(3, "Titanic", "$2,187,463,944", "Yes", "21/03/2017", "Romance", "No"),
                new Movie(4, "Jurassic World", "$1,671,713,208", "No", "02/07/2017", "Science Fiction", "Yes"),
                new Movie(5, "Avengers:End Game", "$2,750,760,348", "No", "02/11/2022", "Superhero", "Yes")
                };

        abstract public List<Movie> GetMovieList();
    }

    public class Admin : User
    {
        string Adminid;
        public string adminid
        {
            get
            {
                return Adminid;

            }
            set
            {
                Adminid = value;
            }
        }

        string AdminName;
        public string adminName
        {
            get
            {
                return AdminName;

            }
            set
            {
                AdminName = value;
            }

        }


        public override List<Movie> GetMovieList()
        {
            return movieList;
        }



        public void DisplayMovieListByAdmin()
        {
            movieList = GetMovieList();
            int i = 1;
            Console.WriteLine("Id       Title           BoxOffice       Active      DateOfLaunch        Genre       HasTeaser");

            foreach (Movie temp in movieList)
            {
                Console.WriteLine("{0,3}  {1,-18}   {2,-6}  {3,-14}  {4}   {5,-15}    {6} ", i, temp.Title, temp.boxOffice, temp.active,temp.dateOfLaunch,temp.Genre, temp.hasTeaser);
                i++;
            }
        }



        public void EditMovie(int k)
        {
            movieList = GetMovieList();
            foreach (Movie temp in movieList)
            {
                if (temp.id == k)
                {
                    Console.WriteLine("Enter Title");
                    temp.Title = Console.ReadLine();
                    //Console.WriteLine("Enter BoxOffice");
                    //temp.BoxOffice = Console.ReadLine();
                    Console.WriteLine("Enter Active");
                    temp.active = Console.ReadLine();
                    Console.WriteLine("Enter DateOfLaunch");
                    temp.dateOfLaunch = Console.ReadLine();
                    Console.WriteLine("Enter Genre");
                    temp.Genre = Console.ReadLine();
                    Console.WriteLine("Enter HasTeaser");
                    temp.hasTeaser = Console.ReadLine();
                    Console.WriteLine("Selected Record Updated Succesfully");

                }
            }
            //GetMovieList(movieList);

        }


    }


    public class Customer : User
    {
        int CustomerId;
        public int customerId
        {
            get
            {
                return CustomerId;
            }
            set
            {
                CustomerId = value;
            }
        }

        string Customername;
        public string customerName
        {
            get
            {
                return Customername;

            }
            set
            {
                Customername = value;
            }
        }

        public Customer() { }

        public Customer(int CustomerId, string CustomerName)
        {
            this.CustomerId = CustomerId;
            this.Customername = CustomerName;
        }

        //public List<Movie> movielist;
        public override List<Movie> GetMovieList()
        {
            return movieList;
        }


        public void DisplayMovieListByCustomer()
        {
            movieList = GetMovieList();
            int i = 1;
            Console.WriteLine("id        Title     BoxOffice        Genre       HasTeaser");
            for (int a = 0; a < movieList.Count - (2); a++)
            {
                Console.WriteLine("{0,3}  {1,-18}    {2,-6}    {3,-16}   {4,-2}", i, movieList[a].Title, movieList[a].boxOffice, movieList[a].Genre, movieList[a].hasTeaser);
                i++;
            }

        }


        //ADD to favorites

        public void AddToFavorites(int id, List<Movie> favorites)
        {
            movieList = GetMovieList();
            int favId, s = 0, count = 0;
            string favTitle;
            string favBoxOffice;
            string favActive;
            string favDateOfLaunch;
            string favGenre;
            string favHasTeaser;
            foreach (Movie temp in movieList)
            {
                count++;
                if (temp.id == id)
                {
                    foreach (Movie emp in favorites)
                    {
                        if (temp.id == emp.id)
                        {
                            s = 1;
                        }
                    }
                    if (s == 0)
                    {
                        favId = temp.id;
                        favTitle = temp.Title;
                        favBoxOffice = temp.boxOffice;
                        favActive = temp.active;
                        favDateOfLaunch = temp.dateOfLaunch;
                        favGenre = temp.Genre;
                        favHasTeaser = temp.hasTeaser;
                        favorites.Add(new Movie(favId, favTitle, favBoxOffice, favActive, favDateOfLaunch, favGenre, favHasTeaser));
                        Console.WriteLine("Added to Favorites Succesfully");
                        Console.WriteLine("The Movies list in Favorites ");
                        ViewFavorites(favorites);

                    }
                    else
                    {
                        Console.WriteLine("The Selected Movie is in Favorites Already");
                    }
                }
            }
            if (count < id)
            {
                Console.WriteLine("Movie index out of bounds");
            }
        }

        //View Favorites

        public void ViewFavorites(List<Movie> favorites)
        {
            int i = 1;
            Console.WriteLine("id       Title       BoxOffice       Genre");
            foreach (Movie temp in favorites)
            {

                Console.WriteLine("{0,3}      {1,-18}     {2,-6}     {3,-16}", i, temp.Title, temp.boxOffice, temp.Genre);
                i++;
            }


        }

        //Remove Favorites

        public void RemoveFavorites(int id, List<Movie> favorites)
        {
            if (favorites.ElementAtOrDefault(id - 1) != null)
            {
                favorites.RemoveAt(id - 1);
                Console.WriteLine("Record Removed Succesfully");
                ViewFavorites(favorites);
            }



            else
                Console.WriteLine("No movie for Selected id");

        }
    }


}