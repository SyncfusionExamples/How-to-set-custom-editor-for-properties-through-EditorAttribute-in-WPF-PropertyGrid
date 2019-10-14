using Syncfusion.Windows.PropertyGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PropertyGrid_EditorAttribute
{
    public class PasswordEditor : ITypeEditor
    {
        public void Attach(PropertyViewItem property, PropertyItem info)
        {
            if (info.CanWrite)
            {
                passwordBox.IsEnabled = true;
            }
            else
            {
                passwordBox.IsEnabled = false;
            }
            passwordBox.Password = info.Value.ToString();
        }

        PasswordBox passwordBox;
        public object Create(PropertyInfo propertyInfo)
        {
            passwordBox = new PasswordBox();
            return passwordBox;
        }

        public void Detach(PropertyViewItem property)
        {
            passwordBox = null;
        }
    }

    public class ImageViewer : ITypeEditor
    {

        public void Attach(PropertyViewItem property, PropertyItem info)
        {

            var binding = new Binding("Value")
            {
                Mode = BindingMode.TwoWay,
                Source = info,
                ValidatesOnExceptions = true,
                ValidatesOnDataErrors = true
            };
            BindingOperations.SetBinding(image, Image.SourceProperty, binding);

        }

        Image image;
        public object Create(PropertyInfo propertyInfo)
        {
            image = new Image();
            image.Source = new BitmapImage();
            image.MaxHeight = 200;
            image.MaxWidth = 200;
            return image;
        }

        public void Detach(PropertyViewItem property)
        {
            image.Source = null;
            image = null;
        }
    }
}
