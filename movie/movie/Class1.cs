
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Com.Cognizant.MovieCruiser.Model
    {
        public class Movie
        {
            int Id;
            public int id
            {
                get
                {
                    return Id;
                }
                set
                {
                    Id = value;
                }
            }


            string title;

            public string Title
            {
                get
                {
                    return title;
                }
                set
                {
                    title = value;
                }
            }


            string BoxOffice;
            public string boxOffice
            {
                get
                {
                    return BoxOffice;
                }
                set
                {
                    BoxOffice = value;
                }

            }

            string Active;
            public string active
            {
                get
                {
                    return Active;
                }
                set
                {
                    Active = value;
                }

            }

            string DateOfLaunch;
            public string dateOfLaunch
            {
                get
                {
                    return DateOfLaunch;
                }
                set
                {
                    DateOfLaunch = value;
                }
            }
            string genre;
            public string Genre
            {
                get
                {
                    return genre;
                }
                set
                {
                    genre = value;
                }
            }
            string HasTeaser;
            public string hasTeaser
            {
                get
                {
                    return HasTeaser;
                }
                set
                {
                    HasTeaser = value;
                }
            }

            public Movie() { }
            public Movie(int id, string Title, string BoxOffice, string Active, string DateOfLaunch, string Genre, string HasTeaser)
            {
                this.id = id;
                this.Title = Title;
                this.BoxOffice = BoxOffice;
                this.Active = Active;
                this.DateOfLaunch = DateOfLaunch;
                this.Genre = Genre;
                this.HasTeaser = HasTeaser;
            }
        }
    }


