using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DbInitializer
    {
        public static void Initialize(WarehouseContext context)
        {
            Category[] categories = new Category[]
            {
                new Category{CategoryName = "Computers", 
                    ShortDescription = "This category contains computers. This is short description.",
                    LongDescription = "Computers are great. They can tell us many things about the world, like how fast this computer is going or how much this house weighs, but there is more to discover. One common application of computers is to help determine the cause of a problem."},
                new Category{CategoryName = "Smartphones", 
                    ShortDescription = "This category contains smartphones. This is short description.",
                    LongDescription = "A smartphone is a portable computer device that combines mobile telephone and computing functions into one unit. They are distinguished from feature phones by their stronger hardware capabilities and extensive mobile operating systems, which facilitate wider software, internet (including web browsing over mobile broadband), and multimedia functionality (including music, video, cameras, and gaming), alongside core phone functions such as voice calls and text messaging."},
                new Category{CategoryName = "Headphones", ShortDescription = "This category contains headphones. This is short description.",
                    LongDescription = "Headphones are a pair of small loudspeaker drivers worn on or around the head over a user's ears. They are electroacoustic transducers, which convert an electrical signal to a corresponding sound."}
            };
            context.Categories.AddRangeAsync(categories);
            context.SaveChanges();

            Good[] goods = new Good[]
            {
                 new Good {GoodName = "Dell PC", ShortDescription ="Powerfull dell pc", LongDescription = "Dell personal computer is a computer produced by Dell. Dell PCs are typically sold with the Dell branded or in some cases licensed operating system of the Windows family or OS X; in addition to the standard model there are the Inspiron, XPS, Alienware and Latitude PCs, which typically come with their own custom firmware or flavors of Linux",
                     Quantity = 10, CategoryId = categories.Where(x => x.CategoryName == "Computers").FirstOrDefault().CategoryId},

                 new Good {GoodName = "MSI PC", ShortDescription ="New msi pc", LongDescription = "Msi personal computer is the standard used to create and manage personal computer systems and is gaining popularity in the last decade as it simplifies the integration of new computer technology such as antivirus software.",
                     Quantity = 15, CategoryId = categories.Where(x => x.CategoryName == "Computers").FirstOrDefault().CategoryId},

                 new Good {GoodName = "Lenovo PC", ShortDescription ="Best perfomance lenovo pc", LongDescription = "Lenovo personal computer is a series of laptops manufactured by Lenovo in the United States. Launched in 1998, the original models offered 14 and 15 screens. Early models lacked a DVD drive, 2.5 GB hard drive, and Windows",
                     Quantity = 20, CategoryId = categories.Where(x => x.CategoryName == "Computers").FirstOrDefault().CategoryId}
            };
            context.Goods.AddRangeAsync(goods);
            context.SaveChanges();
        }
    }
}
