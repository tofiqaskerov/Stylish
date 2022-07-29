using Microsoft.EntityFrameworkCore;
using Stylish.Models;

namespace Stylish.Data
{

    public class DataSeeding
    {
        private readonly AppDbContext _context;
        public DataSeeding(AppDbContext context)
        {
            _context = context;
        }
        public void SeedData()
        {
            if( _context.Database.GetPendingMigrations().Count() == 0)
            {
                if (_context.Banners.Count() == 0)
                    _context.Banners.AddRange(Banners);
                if (_context.Abouts.Count() == 0)
                    _context.Abouts.AddRange(Abouts);
                if (_context.Services.Count() == 0)
                    _context.Services.AddRange(Services);
                if (_context.Callouts.Count() == 0)
                    _context.Callouts.AddRange(Callouts);
                if (_context.Portfolios.Count() == 0)
                    _context.Portfolios.AddRange(Portfolios);
            }
        }
        public static Banner[] Banners =
        {
            new Banner() {
                Title = "Stylish Portfolio",
                Subtitle = "A Free Bootstrap Theme by Start Bootstrap",
                PhotoURL = "https://startbootstrap.github.io/startbootstrap-stylish-portfolio/assets/img/bg-masthead.jpg"
            }
        };
        public static About[] Abouts =
        {
            new About()
            {
                Title = "Stylish Portfolio is the perfect theme for your next project!",
                Subtitle = "This theme features a flexible, UX friendly sidebar menu and stock photos from our friends at ",
                BgColor = "white"
            }
        };
        public static Service[] Services =
        {
            new Service()
            {
                Icon = "fa-mobile",
                Title = "Responsive",
                Subtitle = "Looks great on any screen size!"
            },
            new Service()
            {
                Icon = "fa-pen",
                Title = "Redesigned",
                Subtitle = "Freshly redesigned for Bootstrap 5.Favorited"
            },
            new Service()
            {
                Icon = "fa-thumbs-up",
                Title = "Favorited",
                Subtitle = "Millions of users  Start Bootstrap!"
            },
            new Service()
            {
                Icon = "fa-hashtag",
                Title = "Hashtag",
                Subtitle = "Find out which are the best hashtags to use in your posts on Instagram, Twitter, Facebook or Tumblr to get more likes."
            }

        };
        public static Callout[] Callouts =
        {
            new Callout()
            {
                Title = "Welcome to your next website!",
                PhotoURL = "https://startbootstrap.github.io/startbootstrap-stylish-portfolio/assets/img/bg-callout.jpg"
            }
        };
        public static Portfolio[] Portfolios =
        {
            new Portfolio()
            {
                Title = "STATIONARY",
                Subtitle = "A yellow pencil with envelopes on a clean, blue backdrop!",
                PhotoURL = "https://startbootstrap.github.io/startbootstrap-stylish-portfolio/assets/img/portfolio-1.jpg"
            },
            new Portfolio()
            {
                Title = "ICE CREAM",
                Subtitle = "A dark blue background with a colored pencil, a clip, and a tiny ice cream cone!...",
                PhotoURL = "https://startbootstrap.github.io/startbootstrap-stylish-portfolio/assets/img/portfolio-2.jpg"
            },
            new Portfolio()
            {
                Title = "STRAWBERRIES",
                Subtitle = "Strawberries are such a tasty snack, especially with a little sugar on top!",
                PhotoURL = "https://startbootstrap.github.io/startbootstrap-stylish-portfolio/assets/img/portfolio-3.jpg"
            },
            new Portfolio()
            {
                Title = "WORKSPACE",
                Subtitle = "A yellow workspace with some scissors, pencils, and other objects....",
                PhotoURL = "https://startbootstrap.github.io/startbootstrap-stylish-portfolio/assets/img/portfolio-4.jpg"
            },


        };
    }
}
