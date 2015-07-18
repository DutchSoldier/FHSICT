using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Filesharingapplicatie
{
    public static class FileHelper
    {
        static List<string> images;
        static List<string> videos;
        static List<string> executables;
        static List<string> audio;
        static List<string> text;
        static List<string> office;
        static List<string> compressed;
        static List<string> diskimage;
        
        static FileHelper()
        {
            images = new List<string>();
            images.Add(".bmp");
            images.Add(".gif");
            images.Add(".jpg");
            images.Add(".png");
            images.Add(".psd");
            images.Add(".pspimage");
            images.Add(".thm");
            images.Add(".tif");
            images.Add(".yuv");
            images.Add(".3dm");
            images.Add(".max");
            images.Add(".ai");
            images.Add(".drw");
            images.Add(".eps");
            images.Add(".ps");
            images.Add(".svg");
            images.Add(".ico");
            videos = new List<string>();
            videos.Add(".3g2");
            videos.Add(".3gp");
            videos.Add(".asf");
            videos.Add(".asx");
            videos.Add(".avi");
            videos.Add(".flv");
            videos.Add(".mov");
            videos.Add(".mp4");
            videos.Add(".mpg");
            videos.Add(".rm");
            videos.Add(".swf");
            videos.Add(".vob");
            videos.Add(".wmv");
            executables = new List<string>();
            executables.Add(".app");
            executables.Add(".bat");
            executables.Add(".cgi");
            executables.Add(".com");
            executables.Add(".exe");
            executables.Add(".gadget");
            executables.Add(".jar");
            executables.Add(".pif");
            executables.Add(".vb");
            executables.Add(".wsf");
            audio = new List<string>();
            audio.Add(".aac");
            audio.Add(".aif");
            audio.Add(".iff");
            audio.Add(".m3u");
            audio.Add(".mid");
            audio.Add(".mp3");
            audio.Add(".mpa");
            audio.Add(".ra");
            audio.Add(".wav");
            audio.Add(".wma");
            text = new List<string>();
            text.Add(".txt");
            text.Add(".xml");
            text.Add(".html");
            text.Add(".css");
            text.Add(".htm");
            text.Add(".xhtml");
            text.Add(".c");
            text.Add(".class");
            text.Add(".cpp");
            text.Add(".cs");
            text.Add(".dtd");
            text.Add(".java");
            text.Add(".m");
            text.Add(".pl");
            text.Add(".csv");
            text.Add(".dat");
            text.Add(".asp");
            text.Add(".js");
            text.Add(".jsp");
            text.Add(".php");
            text.Add(".rss");
            text.Add(".log");
            office = new List<string>();
            office.Add(".accdb");
            office.Add(".accdt");
            office.Add(".doc");
            office.Add(".docm");
            office.Add(".docx");
            office.Add(".dot");
            office.Add(".dotm");
            office.Add(".dotx");
            office.Add(".mdb");
            office.Add(".mpp");
            office.Add(".mpt");
            office.Add(".one");
            office.Add(".onepkg");
            office.Add(".pot");
            office.Add(".potx");
            office.Add(".pps");
            office.Add(".ppsx");
            office.Add(".ppt");
            office.Add(".pptm");
            office.Add(".pptx");
            office.Add(".pst");
            office.Add(".pub");
            office.Add(".snp");
            office.Add(".thmx");
            office.Add(".xls");
            office.Add(".xlsm");
            office.Add(".xlsx");
            office.Add(".pdf");
            office.Add(".vsd");
            compressed = new List<string>();
            compressed.Add(".7z");
            compressed.Add(".deb");
            compressed.Add(".gz");
            compressed.Add(".pkg");
            compressed.Add(".rar");
            compressed.Add(".sit");
            compressed.Add(".sitx");
            compressed.Add(".tar.gz");
            compressed.Add(".zip");
            compressed.Add(".zipx");
            diskimage = new List<string>();
            diskimage.Add(".dmg");
            diskimage.Add(".iso");
            diskimage.Add(".toast");
            diskimage.Add(".vcd");
        }

        public static string getGrootte(long bytes)
        {
            string grootte = "";

            if (bytes >= 1073741824)
            {
                decimal gigabytes = Convert.ToDecimal(bytes) / 1073741824;
                gigabytes = Math.Round(gigabytes, 2);
                grootte = gigabytes.ToString() + " GB";
            }
            else if (bytes >= 1048576)
            {
                decimal megabytes = Convert.ToDecimal(bytes) / 1048576;
                megabytes = Math.Round(megabytes, 2);
                grootte = megabytes.ToString() + " MB";
            }
            else if (bytes >= 1024)
            {
                decimal kilobytes = Convert.ToDecimal(bytes) / 1024;
                kilobytes = Math.Round(kilobytes, 2);
                grootte = kilobytes.ToString() + " kB";
            } 
            else
            {
                grootte = bytes.ToString() + " B";
            }
            return grootte;
        }   // krijgt een aantal bytes en returned een string waarin de grootte overzichtelijker is gemaakt

        public static int getImageindex(string extension)
        {
            if (images.Contains(extension))
            {
                return 1;
            }
            if (videos.Contains(extension))
            {
                return 2;
            }
            if (executables.Contains(extension))
            {
                return 3;
            }
            if (audio.Contains(extension))
            {
                return 4;
            }
            if (text.Contains(extension))
            {
                return 5;
            }
            if (office.Contains(extension))
            {
                return 6;
            }
            if (compressed.Contains(extension))
            {
                return 7;
            }
            if (diskimage.Contains(extension))
            {
                return 11;
            }
            else
            {
                return 8;
            }
        }   // krijgt een extension en returned welke image de file moet krijgen
    }
}
