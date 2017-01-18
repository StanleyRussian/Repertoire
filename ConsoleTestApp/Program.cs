using System;
using System.Linq;
using LiteDatabase;

namespace ConsoleTestApp
{
    class Program
    {
        private static EntityModel model = new EntityModel();

        static void Main(string[] args)
        {
            foreach (var group in model.Groups)
            {
                var SongsInGroup = model.Songs.Where(x => x.Groups.Any(y => y.Id == group.Id));
                if (SongsInGroup.Any())
                {
                    Console.WriteLine("Group: " + group.Name);
                    PrintSongsOfGroup(SongsInGroup);
                }
                else
                    Console.WriteLine("Empty group: " + group.Name + "\n");
            }

            var SongsWithoutGroup = model.Songs.Where(x => !x.Groups.Any());
            Console.WriteLine("\nDon't belong to any group: ");
            PrintSongsOfGroup(SongsWithoutGroup);
            Console.ReadLine();
        }

        private static void PrintSongsOfGroup(IQueryable<Song> SongsInGroup)
        {
            foreach (var genre in model.Genres)
            {
                var SongsOfGenre = SongsInGroup.Where(x => x.Genre.Id == genre.Id);
                if (SongsOfGenre.Any())
                {
                    Console.WriteLine("  Genre: " + genre.Name);
                    foreach (var song in SongsOfGenre)
                    {
                        Console.WriteLine("    " + song.Artist.Name + " - " + song.Title + "\"");
                        foreach (var filepath in song.Filepaths)
                            Console.WriteLine("      " + filepath.Path);
                        Console.Write("      Progress:\t");
                        foreach (var node in song.ProgressNodes)
                            Console.Write(node.Name + "\t");
                        Console.WriteLine("\n    " + song.Status.Name + "\n");
                    }
                }
            }
        }
    }
}