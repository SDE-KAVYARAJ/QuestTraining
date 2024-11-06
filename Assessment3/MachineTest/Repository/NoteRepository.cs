using Assessment.Model;
using log4net;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment.Repository
{
    internal class NoteRepository
    {
        private readonly string connectionString;
        private readonly ILog log;
        public NoteRepository(string connectionString, ILog log)
        {
            this.connectionString = connectionString;
            this.log = log;
        }

        public void AddNote(Note note)
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                {
                    connection.Open();
                    var query = "INSERT INTO Notes (Title, Content, CreatedAt) VALUES (@Title, @Content, @CreatedAt)";
                    var command = new SqlCommand(query, connection);
                    {
                        command.Parameters.AddWithValue("@Title", note.Title);
                        command.Parameters.AddWithValue("@Content", note.Content);
                        command.Parameters.AddWithValue("@CreatedAt", note.CreatedAt);
                        command.ExecuteNonQuery();
                    }
                        
                     log.Info($"Note created: {note.Title} (ID: {note.NoteID})");
                }
            }
            catch (Exception ex)
            {
                log.Error("Error adding note", ex);
                
            }
        }

        public List<Note> GetAllNotes()
        {
            var notes = new List<Note>();
            try
            {
                var connection = new SqlConnection(connectionString);
                {
                    connection.Open();
                    var query = "SELECT NoteID, Title, Content, CreatedAt, UpdatedAt FROM Notes";
                    var command = new SqlCommand(query, connection);
                    var reader = command.ExecuteReader();
                    {
                        while (reader.Read())
                        {
                            notes.Add(new Note
                            {
                                NoteID = reader.GetInt32(0),
                                Title = reader.GetString(1),
                                Content = reader.GetString(2),
                                CreatedAt = reader.GetDateTime(3),
                                UpdatedAt = reader.IsDBNull(4) ? (DateTime?)null : reader.GetDateTime(4)
                            });
                        }
                    }
                }
                log.Info("Fetched all notes from the database.");
            }
            catch (Exception ex)
            {
                log.Error("Error retrieving notes", ex);
                
            }
            return notes;
        }

        public void UpdateNote(Note note)
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                {
                    connection.Open();
                    var query = "UPDATE Notes SET Title = @Title, Content = @Content, UpdatedAt = @UpdatedAt WHERE NoteID = @NoteID";
                    var command = new SqlCommand(query, connection);
                    {
                        command.Parameters.AddWithValue("@Title", note.Title);
                        command.Parameters.AddWithValue("@Content", note.Content);
                        command.Parameters.AddWithValue("@UpdatedAt", note.UpdatedAt);
                        command.Parameters.AddWithValue("@NoteID", note.NoteID);
                        command.ExecuteNonQuery();
                    }
                }
                
                log.Info($"Note updated: {note.Title} (ID: {note.NoteID})");

            }
            catch (Exception ex)
            {
                log.Error("Error updating note", ex);
                
            }
        }

        public void DeleteNoteById(int noteID)
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                {
                    connection.Open();
                    var query = "DELETE FROM Notes WHERE NoteID = @NoteID";
                    var command = new SqlCommand(query, connection);
                    {
                        command.Parameters.AddWithValue("@NoteID", noteID);
                        command.ExecuteNonQuery();
                    }
                }
                log.Info($"Note deleted: ID {noteID}");
                
            }
            catch (Exception ex)
            {
                log.Error("Error deleting note", ex);
                
            }
        }

    }
}
