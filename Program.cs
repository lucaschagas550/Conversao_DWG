using Aspose.CAD;
using System;
using System.IO;
using System.Linq;

namespace Conversion_DWG
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("INICIO DO PROCESSO: " + DateTime.Now);

            //==============================================================
            //string path = @"\\10.21.1.176\Raymound"; // Administrative share 
            string path = @"\\10.21.0.22\Inobag\Publico\LucasChagas\Raymond"; // Valid share name

            DirectoryInfo Dir = new DirectoryInfo(@$"{path}");
            FileInfo[] Files = Dir.GetFiles("*", SearchOption.AllDirectories);

            var directory = Files.FirstOrDefault(o => o.FullName.Contains("36000995"));
            Console.WriteLine("BUSCANDO DIRETORIOS: " + DateTime.Now);

            var files = Directory.GetFiles(directory.DirectoryName);
            Console.WriteLine("BUSCANDO ARQUIVO: " + DateTime.Now);

            path = $@"{files.FirstOrDefault(o => o.Contains("109"))}";

            using (var image = Image.Load(@$"{path}"))
            {
                Console.WriteLine("TRANSFORMANDO IMAGEM: " + DateTime.Now);

                var rasterizationOptions = new Aspose.CAD.ImageOptions.CadRasterizationOptions()
                {
                    PageWidth = 2160,
                    PageHeight = 2160,
                    DrawColor = Color.DarkBlue
                };

                var options = new Aspose.CAD.ImageOptions.PngOptions();

                options.VectorRasterizationOptions = rasterizationOptions;

                image.Save(@$"C:\Imagens\testeRaymound.png", options);

                Console.WriteLine("FINAL DO PROCESSO: " + DateTime.Now);
            }
        }
    }
}
