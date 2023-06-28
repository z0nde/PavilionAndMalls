using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Windows;
using System.Windows.Media.Imaging;
using PavilionAndMalls.Pages;
using System.Security.Claims;
using System.Windows.Documents;

namespace PavilionAndMalls
{
    public class PhotoConverter
    {
        public static BitmapImage ToImage(byte[]? array) 
        {
            using (MemoryStream ms = new MemoryStream(array))
            {
                var image = new BitmapImage();
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = ms;
                image.EndInit();
                return image;
            }
        }

        public static byte[] ToByteArrWithPath(string Path)
        {
            return File.ReadAllBytes(Path);
        }

        private static void TransferringFolderToDatabase()
        {
            try
            {
                int i = 0;
                string path = "";
                //C:\Users\z0nde\Desktop\3 курс. учёба\UP_KP\PhotoForFill\Malls
                foreach (var s in PavilionsContext.GetContext().Malls)
                {
                    ++i;
                    path = $"C:\\Users\\z0nde\\Desktop\\3 курс. учёба\\UP_KP\\PhotoForFill\\Malls\\{i}.jpg";
                    s.MallPicture = ToByteArrWithPath(path);
                }

                i = 0;
                //C:\Users\z0nde\Desktop\3 курс. учёба\UP_KP\PhotoForFill\Employee
                foreach (var s in PavilionsContext.GetContext().Employees)
                {
                    ++i;
                    path = $"C:\\Users\\z0nde\\Desktop\\3 курс. учёба\\UP_KP\\PhotoForFill\\Employee\\({i}).jpg";
                    s.EmployeePhoto = ToByteArrWithPath(path);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            PavilionsContext.GetContext().SaveChanges();
        }
    }
}