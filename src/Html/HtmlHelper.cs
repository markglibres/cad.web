using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;

namespace CAD.Web
{
    public class HtmlHelper
    {
        //http://www.dailycoding.com/posts/convert_image_to_base64_string_and_base64_string_to_image.aspx
        public static string ConvertImageFileToEmbedded(string imageUrl)
        {
            string embeddedFormat = "data:{0};base64,{1}"; //contentType, base64 format
            string contentTypeFormat = "image/{0}";
            string contentType = "image/{0}";
            string imageBase64 = String.Empty;

            var converter = new ImageFormatConverter();
            
            using (MemoryStream stream = new MemoryStream())
            {
                Image image = Image.FromFile(imageUrl);
                image.Save(stream, image.RawFormat);
                byte[] imageBytes = stream.ToArray();
                imageBase64 = Convert.ToBase64String(imageBytes);
                contentType = String.Format(contentTypeFormat, converter.ConvertToString(image.RawFormat).ToLower());
            }

            string convertedSrc = String.Format(embeddedFormat, contentType, imageBase64);

            return convertedSrc;
        }

        public static string ConvertToEmbeddedImages(string htmlText)
        {
            string regexFormat = "<img.+?src=[\"'](.+?)[\"'].+?>";
            Regex regex = new Regex(regexFormat);

            HtmlHelper helper = new HtmlHelper();
            var convertedHtml = regex.Replace(htmlText, helper.ImageSrcFileReplace);
            return convertedHtml;

        }

        private string ImageSrcFileReplace(Match match)
        {
            string src = match.Groups[1].Captures[0].Value;
            src = HtmlHelper.ConvertImageFileToEmbedded(src);
            src = "src=\"" + src + "\"";

            string replaced = Regex.Replace(match.Value, "src=[\"'].+?[\"']", src);

            return replaced;
        }
    }
}
