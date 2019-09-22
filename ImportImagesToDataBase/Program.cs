using System;
using System.Drawing;
using System.IO;


namespace ImportImagesToDataBase
{
    class Program
    {
        static void Main(string[] args)
        {




        }

        private Byte[] ConvertImageToByte(string path)
        {
            //создаем объект картинки
            Bitmap image = new Bitmap(path);
            //открываем поток для перевода картинки в байты 
            using (MemoryStream ms = new MemoryStream())
            {
                //сохраняем картинку в поток 
                image.Save(ms , image.RawFormat);
                //возращаем массив байт картинки
                return ms.ToArray(); 
            }


        }
    }
}
