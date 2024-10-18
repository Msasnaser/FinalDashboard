using System.IO;

namespace feliciano.PL.Helpers
{

    //نكتب فيه الفنكشنز اللي الخاصة بالتعامل مع الملفات
    public class FilesSetting
    {
        //public static string UplodeFile(IFormFile file , string FolderName)
        //{
        //    //string FolderPath = Directory.GetCurrentDirectory()+"\\wwwroot\\files\\BlogImages\\"+ FolderName;

        //    //وين بدي اخزن الفايل
        // string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName);

        //    if (!Directory.Exists(FolderPath))
        //    {
        //        Directory.CreateDirectory(FolderPath);
        //    }

        //    //اسم الفايل  
        //    string FileName = $"{Guid.NewGuid()}{file.FileName}";
        //    //
        //    string FilePath = Path.Combine(FolderPath, FileName);

        //    var fileStream = new FileStream(FilePath, FileMode.Create);

        //    file.CopyTo(fileStream);
        //    return FileName;
        //}
        public static string UplodeFile(IFormFile file, string FolderName)
        {
            try
            {
                // Combine the folder path
                string FolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName);

                // Create the directory if it doesn't exist
                if (!Directory.Exists(FolderPath))
                {
                    Directory.CreateDirectory(FolderPath);
                }

                // Generate a unique file name
                string FileName = $"{Guid.NewGuid()}_{Path.GetFileName(file.FileName)}";

                // Combine the full file path
                string FilePath = Path.Combine(FolderPath, FileName);

                // Open a file stream to save the file
                using (var fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return FileName;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error uploading file: {ex.Message}");
                return null; // Return null if there's an error
            }
        }


        public static void DeleteFile(string FolderName, string FileName)
        {
            string FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\files", FolderName, FileName);

            if(File.Exists(FilePath) ) {
            File.Delete(FilePath);
            }
        }
    }
}
