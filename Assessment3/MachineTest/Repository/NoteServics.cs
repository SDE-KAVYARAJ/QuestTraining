using Assessment.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Repository
{
    internal class NoteService
    {
        private readonly NoteRepository noteRepository;
        private readonly ILog log;
        public NoteService(NoteRepository repository, ILog log)
        {
            noteRepository = repository;
            this.log = log;
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\nNote-Taking Application");
                Console.WriteLine("1. Create a new note");
                Console.WriteLine("2. View all notes");
                Console.WriteLine("3. Update an existing note");
                Console.WriteLine("4. Delete a note");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNote();
                        break;
                    case "2":
                        ViewAllNotes();
                        break;
                    case "3":
                        UpdateNote();
                        break;
                    case "4":
                        DeleteNote();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        private void CreateNote()
        {
            Console.Write("Enter title: ");
            var title = Console.ReadLine();
            Console.Write("Enter content: ");
            var content = Console.ReadLine();

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
            {
                Console.WriteLine("Title and content cannot be empty.");
                return;
            }

            var note = new Note
            {
                Title = title,
                Content = content,
                CreatedAt = DateTime.Now
            };
            noteRepository.AddNote(note);
            log.Info("Created a new note.");
        }

        private void ViewAllNotes()
        {
            var notes = noteRepository.GetAllNotes();
            Console.WriteLine("\nNotes:");
            foreach (var note in notes)
            {
                Console.WriteLine($"ID: {note.NoteID}, Title: {note.Title}, CreatedAt: {note.CreatedAt}");
                Console.WriteLine($"Contents: {note.Content}...");
            }
        }

        private void UpdateNote()
        {
            Console.Write("Enter Note ID to update: ");
            int noteID = int.Parse(Console.ReadLine());
            var notes = noteRepository.GetAllNotes();
            var note = notes.Find(n => n.NoteID == noteID);
                if (note == null)
                {
                    Console.WriteLine("Note not found.");
                    return;
                }

            Console.Write("Enter new title (leave blank to keep current): ");
            var newTitle = Console.ReadLine();
            if (!string.IsNullOrEmpty(newTitle))
            {
                note.Title = newTitle;
            }

            Console.Write("Enter new content (leave blank to keep current): ");
            var newContent = Console.ReadLine();
            if (!string.IsNullOrEmpty(newContent))
            {
                note.Content = newContent;
            }

            note.UpdatedAt = DateTime.Now;
            noteRepository.UpdateNote(note);
            log.Info($"Updated note ID {note.NoteID}.");

        }

        private void DeleteNote()
        {
            Console.Write("Enter note ID to delete: ");
            int noteID = int.Parse(Console.ReadLine());
            noteRepository.DeleteNoteById(noteID);
            log.Info($"Deleted note ID {noteID}.");
        }
    }
}
