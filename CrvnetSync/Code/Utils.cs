using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Text.RegularExpressions;

namespace CrvnetSync.Code
{
    public class Utils
    {
        public static string ImageToBase64(string imgPat)
        {
            using (Image image = Image.FromFile(imgPat))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    // Convert byte[] to Base64 String
                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }

        public static bool ContainsLetters(string word)
        {
            var totalLetters = Regex.Matches(word, @"[a-zA-Z]").Count;
            return totalLetters > 0;
        }

    }
}
