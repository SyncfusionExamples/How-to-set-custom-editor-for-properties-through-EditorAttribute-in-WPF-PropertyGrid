using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PropertyGrid_EditorAttribute
{
    [Editor(typeof(ImageSource), typeof(ImageViewer))]
    public class Person
    {
        public Person()
        {
            FirstName = "Carl";
            Age = 30;
            Email = "carljohnson@gta.com";
            ID = "0005A";
            DOB = new DateTime(1987, 10, 16);
            string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            Image = new BitmapImage(new Uri(path + @"\carl.png", UriKind.RelativeOrAbsolute));
            Designation = "Team Lead";
        }
      
        public Country Country
        {
            get;

            set;
        }

        public string Email
        {
            get;

            set;
        }

        public string FirstName
        {
            get;

            set;
        }

        public string Designation
        {
            get;

            set;
        }

        public string ID
        {
            get;

            set;
        }


        public DateTime DOB
        {
            get;

            set;
        }
        
        public int Age
        {
            get;

            set;
        }

        public ImageSource Image
        {
            get;

            set;
        }
    }

    public enum Country
    {
        UnitedStates,

        Germany,

        Canada,

        Mexico,

        Alaska,

        Japan,

        China,

        Peru,

        Chile,

        Argentina,

        Brazil
    }
}
