using System;
using System.Data.Entity;
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
                Console.WriteLine("Group: " + group.Name);
                if (SongsInGroup.Any())
                    PrintSongsOfGroup(SongsInGroup);
                else
                    Console.WriteLine("EMPTY\n");
            }

            var SongsWithoutGroup = model.Songs.Where(x => !x.Groups.Any());
            if (SongsWithoutGroup.Any())
            {
                Console.WriteLine("Don't belong to any group: ");
                PrintSongsOfGroup(SongsWithoutGroup);
            }

            Console.ReadLine();
        }

        private static void PrintSongsOfGroup(IQueryable<Song> argSongsInGroup)
        {
            foreach (var genre in model.Genres)
            {
                var SongsOfGenre = argSongsInGroup.Where(x => x.Genre.Id == genre.Id);
                if (SongsOfGenre.Any())
                {
                    Console.WriteLine("|--Genre: " + genre.Name);
                    PrintSongsOfGenre(SongsOfGenre);
                }
            }

            var SongsWithoutGenre = argSongsInGroup.Where(x=>x.Genre == null);
            if (SongsWithoutGenre.Any())
            {
                Console.WriteLine("|--Without Genre:");
                PrintSongsOfGenre(SongsWithoutGenre);
            }
            Console.WriteLine();
        }

        private static void PrintSongsOfGenre(IQueryable<Song> argSongsInGenre)
        {
            foreach (var song in argSongsInGenre)
            {
                Console.WriteLine("|  |--" + song.Artist.Name + " - \"" + song.Title + "\" - " + song.Status.Name);

                foreach (var filepath in song.Filepaths)
                    Console.WriteLine("|  |     " + filepath.Path);

                Console.Write("|  |     Progress:\t");

                model.ProgressNodes.Load();
                foreach (var nodeSong in song.rProgressNodeSongs)
                {
                    if (nodeSong.ProgressNode == null)
                    {
                        Console.Write("! ");
                        Console.Write(model.ProgressNodes.Find(nodeSong.ProgressNodeId).Name + "\t");
                    }
                    else
                    Console.Write(nodeSong.ProgressNode.Name + "\t");
                }

                Console.WriteLine();
            }
        }
    }
}