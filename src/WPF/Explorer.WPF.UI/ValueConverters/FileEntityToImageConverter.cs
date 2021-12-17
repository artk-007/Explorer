using SharpVectors.Converters;
using SharpVectors.Renderers.Wpf;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ExplorER;

namespace Explorer.WPF.UI
{
    internal class FileEntityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var drawingImage = new DrawingImage();

            if (!(value is FileEntityViewModel viewModel))
                return drawingImage;

                var imagePath = ExplorerEr.Instance.IconsManager.GetIconPath(viewModel);


                if (imagePath.Extension.ToUpper() == ".SVG")
                {
                    var settings = new WpfDrawingSettings
                    {
                        TextAsGeometry = false,
                        IncludeRuntime = true,
                            
                    };
                    var converter = new FileSvgReader(settings);

                    var drawing = converter.Read(imagePath.FullName);

                    if (drawing != null)
                        return new DrawingImage(drawing);
                }
                else
                {
                    var bitmapSource = new BitmapImage(new Uri(imagePath.FullName));
                    return bitmapSource;
                }

                return drawingImage;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
