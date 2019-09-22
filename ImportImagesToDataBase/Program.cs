
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;


namespace ImportImagesToDataBase
{
    class Program
    {
        //импорт картинок в базу данных 
        [STAThread]
        static void Main(string[] args)
        {
            TestImagesEntities context = new TestImagesEntities();

            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Multiselect = true; 
            if (openFile.ShowDialog().Value)
            {
                string[] fileNames = openFile.FileNames;
                foreach (string fileName in fileNames)
                {
                    byte[] image = null; 
                    image = ConvertImageToByte(fileName);
                    context.Images.Add(new Images() { name = "fdsa", image = image });
                }
               
            }
            context.SaveChanges();

            Console.WriteLine("Success"); 
            

            Console.ReadLine();

        }

        private static byte[] ConvertImageToByte(string path)
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
