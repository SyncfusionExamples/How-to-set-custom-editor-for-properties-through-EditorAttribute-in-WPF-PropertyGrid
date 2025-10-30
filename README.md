# WPF PropertyGrid – Set a custom editor via EditorAttribute
## Overview 
The PropertyGrid control is a powerful tool for displaying and editing the properties of an object in a structured and user-friendly manner. One of its key features is the ability to assign custom editors to specific properties, allowing developers to enhance the editing experience beyond the default behavior. 

Syncfusion WPF PropertyGrid lets you replace default editors with custom ones using the .NET EditorAttribute. Using custom editors improves usability, ensures data consistency, and provides a more intuitive interface for end users. This is useful for constrained input (dropdowns), visual selection (color pickers), or richer UI than a TextBox.

## How it works
- Implement an editor that implements Syncfusion.Windows.PropertyGrid.ITypeEditor and returns a WPF control (FrameworkElement).
- Annotate the target property with [Editor(typeof(YourEditor), typeof(ITypeEditor))].
- PropertyGrid will instantiate your editor for that property.

## XAML (MainWindow.xaml)
```XAML
    <Grid>
        <propertyGrid:PropertyGrid x:Name="pgrid">
            <propertyGrid:PropertyGrid.SelectedObject>
                <local:Person/>
            </propertyGrid:PropertyGrid.SelectedObject>
        </propertyGrid:PropertyGrid>
    </Grid>
```
## Custom editor for image viewer
```C#
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
```
## Set custom editor through editor attribute
```C#
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
      
        public Country Country { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string Designation { get; set; }

        public string ID { get; set; }

        public DateTime DOB { get; set; }

        public int Age { get; set; }

        public ImageSource Image { get; set; }
    }
```
