using FoodiesLoungeModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodiesLoungeUtilities
{
    public class Utility
    {

        public Utility()
        {


        }
        public static void fileupload(MenuItem menuItem, string fileName_new, IFormFileCollection files, string extension,string uploads)
        {

           
               

                using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                menuItem.Image = @"\Images\MenuItems\" + fileName_new + extension;
            
        }
        public static void filedelete(MenuItem menuItem, string fileName_new, IFormFileCollection files, string extension, string uploads, string webRoothPath)
        {


           

            var OLdImagePath = Path.Combine(webRoothPath, menuItem.Image.TrimStart('\\'));
            if (System.IO.File.Exists(OLdImagePath))
            {
                System.IO.File.Delete(OLdImagePath);
            }

            using (var fileStream = new FileStream(Path.Combine(uploads, fileName_new + extension), FileMode.Create))
            {
                files[0].CopyTo(fileStream);
            }

        }
    }
}
